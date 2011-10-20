using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.VSX.Trackers
{
    /// <summary>
    /// Build Tracker used to track build events for solution and project builds.
    /// </summary>
    public class BuildTracker : IVsUpdateSolutionEvents2
    {
        private static Dictionary<string, ProjectTypeDef> projectTypeDefCache = new Dictionary<string, ProjectTypeDef>();
        private DTE dte;
        private readonly IAchievementService _achievementService;
        private DateTime lastAchievementCheck = DateTime.Now;
        private bool isAchievementDetectionRunning;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildTracker"/> class.
        /// </summary>
        /// <param name="dte">The DTE.</param>
        /// <param name="achievementService"></param>
        public BuildTracker(DTE dte, IAchievementService achievementService)
        {
            this.dte = dte;
            _achievementService = achievementService;
        }

        /// <summary>
        /// Called before any build actions have begun. This is the last chance to cancel the build before any building begins.
        /// </summary>
        /// <param name="pfCancelUpdate">Pointer to a flag indicating cancel update.</param>
        /// <returns>
        /// If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an error code.
        /// </returns>
        int IVsUpdateSolutionEvents.UpdateSolution_Begin(ref int pfCancelUpdate)
        {
            if (isAchievementDetectionRunning)
            {
                // Cancel build if detection is currently running.
                pfCancelUpdate = 1;

                return VSConstants.S_OK;
            }

            return VSConstants.S_OK;
        }

        /// <summary>
        /// Called when a build is completed.
        /// </summary>
        /// <param name="fSucceeded"><c>true</c> if no update actions failed.</param>
        /// <param name="fModified"><c>true</c> if any update action succeeded.</param>
        /// <param name="fCancelCommand"><c>true</c> if update actions were canceled.</param>
        /// <returns>
        /// If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an error code.
        /// </returns>
        int IVsUpdateSolutionEvents.UpdateSolution_Done(int fSucceeded, int fModified, int fCancelCommand)
        {
            if (fSucceeded != 0)
            {
                try
                {
                    ProjectTypeDef projectTypeDef = null;

                    if (dte.ActiveDocument != null && dte.ActiveDocument.ProjectItem != null && dte.ActiveDocument.ProjectItem.ContainingProject != null)
                    {
                        var containingProject = dte.ActiveDocument.ProjectItem.ContainingProject;

                        var projectFile = containingProject.FileName;
                        if (!string.IsNullOrEmpty(projectFile) && !projectTypeDefCache.TryGetValue(projectFile, out projectTypeDef))
                        {
                            XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
                            var csProj = XDocument.Load(containingProject.FileName);
                            var strokesAchievementTypeNodes = csProj.Descendants(ns + "StrokesProjectType");
                            var strokesAchievementTypeNode = strokesAchievementTypeNodes.FirstOrDefault();
                            if (strokesAchievementTypeNode != null && strokesAchievementTypeNode.HasElements)
                            {
                                projectTypeDef = new ProjectTypeDef()
                                {
                                    IsAchievementProject = strokesAchievementTypeNode.Elements().Any(a => a.Name == ns + "Achievements" && a.Value == "true"),
                                    IsChallengeProject = strokesAchievementTypeNode.Elements().Any(a => a.Name == ns + "Challenges" && a.Value == "true")
                                };

                                projectTypeDefCache.Add(projectFile, projectTypeDef);
                            }
                        }
                    }

                    if (projectTypeDef == null)
                    {
                        projectTypeDef = new ProjectTypeDef(); // Assume default values (false, false);
                    }

                    // Return out if we're not compiling an achievement project.
                    if (!projectTypeDef.IsAchievementProject && !projectTypeDef.IsChallengeProject)
                    {
                        return VSConstants.S_OK;
                    }

                    // Get all .cs files in solution projects, that has changed since lastAchievementCheck
                    var changedFiles = FileTracker.GetFiles(dte.Solution);

                    // Update lastAchievementCheck
                    lastAchievementCheck = DateTime.Now;

                    // Construct build information
                    var buildInformation = new StaticAnalysisManifest();
                    buildInformation.CodeFiles = FileTracker.GetFiles(dte.Solution).ToArray();

                    var activeDocument = dte.ActiveDocument;
                    if (activeDocument != null)
                    {
                        var documentFile = activeDocument.FullName;

                        if (documentFile.EndsWith(".cs"))
                        {
                            buildInformation.ActiveFile = documentFile;

                            if (!changedFiles.Contains(documentFile))
                            {
                                // Always check active document.
                                changedFiles.Add(documentFile);
                            }

                            // Fill relevant values on StaticAnalysisManifest
                            var projectItem = activeDocument.ProjectItem.ContainingProject;
                            buildInformation.ActiveProject = projectItem.FileName;
                            buildInformation.ActiveProjectOutputDirectory = FileTracker.GetProjectOutputDirectory(projectItem);
                        }
                    }

                    buildInformation.ChangedFiles = changedFiles.ToArray();

                    // Validate build information
                    if (buildInformation.ActiveProject == null && buildInformation.ChangedFiles.Length == 0)
                    {
                        // Build information contains nothing - so we won't detect achievements
                        return VSConstants.S_OK;
                    }

                    // Lock builds while detection is occuring - this prevents parallel detection
                    isAchievementDetectionRunning = true;
                    _achievementService.PerformStaticAnalysis(buildInformation);
                }
                finally
                {
                    // Unlock builds
                    isAchievementDetectionRunning = false;
                }
            }

            return VSConstants.S_OK;
        }

        #region Unused Events

        public int UpdateProjectCfg_Begin(IVsHierarchy pHierProj, IVsCfg pCfgProj, IVsCfg pCfgSln, uint dwAction, ref int pfCancel)
        {
            return VSConstants.S_OK;
        }

        public int UpdateProjectCfg_Done(IVsHierarchy pHierProj, IVsCfg pCfgProj, IVsCfg pCfgSln, uint dwAction, int fSuccess, int fCancel)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents2.UpdateSolution_StartUpdate(ref int pfCancelUpdate)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents2.UpdateSolution_Done(int fSucceeded, int fModified, int fCancelCommand)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents2.UpdateSolution_Cancel()
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents2.OnActiveProjectCfgChange(IVsHierarchy pIVsHierarchy)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents2.UpdateSolution_Begin(ref int pfCancelUpdate)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents.UpdateSolution_StartUpdate(ref int pfCancelUpdate)
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents.UpdateSolution_Cancel()
        {
            return VSConstants.S_OK;
        }

        int IVsUpdateSolutionEvents.OnActiveProjectCfgChange(IVsHierarchy pIVsHierarchy)
        {
            return VSConstants.S_OK;
        }

        #endregion
    }

    internal class ProjectTypeDef
    {
        public bool IsAchievementProject;
        public bool IsChallengeProject;
    }
}
