using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Strokes.Core;

namespace Strokes.VSX.Trackers
{
    /// <summary>
    /// Build Tracker used to track build events for solution and project builds.
    /// </summary>
    public class BuildTracker : IVsUpdateSolutionEvents2
    {
        private DTE dte;
        private DateTime lastAchievementCheck = DateTime.Now;
        private bool isAchievementDetectionRunning;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildTracker"/> class.
        /// </summary>
        /// <param name="dte">The DTE.</param>
        public BuildTracker(DTE dte)
        {
            this.dte = dte;
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
                    // Get all .cs files in solution projects, that has changed since _lastAchievementCheck
                    var changedFiles = FileTracker.GetChangedFiles(dte.Solution, lastAchievementCheck);

                    // Update _lastAchievementCheck
                    lastAchievementCheck = DateTime.Now;

                    // Construct build information
                    var buildInformation = new BuildInformation();

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

                            // Fill relevant values on buildInformation
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

                    DetectionDispatcher.Dispatch(buildInformation);
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
}
