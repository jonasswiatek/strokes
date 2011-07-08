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
    public class BuildTracker : IVsUpdateSolutionEvents2
    {
        private DTE dte;

        public BuildTracker(DTE dte)
        {
            this.dte = dte;
        }

        //When we last checked for achievements (used to track which files should be checked upon build. This could be changed to DateTime.Min to ensure that everything is checked on first compile
        private DateTime _lastAchievementCheck = DateTime.Now;

        //Used to block builds while achievements are being detected. Too much rape?
        private bool _isAchievementDetectionRunning;

        //Gets called just before a build, and can cancel it if needed.
        int IVsUpdateSolutionEvents.UpdateSolution_Begin(ref int pfCancelUpdate)
        {
            if (_isAchievementDetectionRunning)
            {
                pfCancelUpdate = 1; //Cancel build if detection is currently running.

                return VSConstants.S_OK;
            }

            return VSConstants.S_OK;
        }

        //Gets called after a build
        int IVsUpdateSolutionEvents.UpdateSolution_Done(int fSucceeded, int fModified, int fCancelCommand)
        {
            if (fSucceeded != 0)
            {
                try
                {
                    //Get all .cs files in solution projects, that has changed since _lastAchievementCheck
                    var changedFiles = FileTracker.GetChangedFiles(dte.Solution, _lastAchievementCheck);

                    //Update _lastAchievementCheck
                    _lastAchievementCheck = DateTime.Now;

                    //Construct build information
                    var buildInformation = new BuildInformation();

                    var activeDocument = dte.ActiveDocument;
                    if (activeDocument != null)
                    {
                        var documentFile = activeDocument.FullName;

                        if (documentFile.EndsWith(".cs"))
                        {
                            if (!changedFiles.Contains(documentFile))
                            {
                                //Always check active document.
                                changedFiles.Add(documentFile);
                            }

                            var projectItem = activeDocument.ProjectItem.ContainingProject;
                            buildInformation.ChangedFiles = changedFiles.ToArray();
                            buildInformation.ActiveProject = projectItem.FileName;
                        }
                    }

                    //Validate build information
                    if (buildInformation.ActiveProject == null && buildInformation.ChangedFiles.Length == 0)
                    {
                        //Build information contains nothing - so we won't detect achievements
                        return VSConstants.S_OK;
                    }

                    //Lock builds while detection is occuring - this prevents parallel detection
                    _isAchievementDetectionRunning = true;

                    //Dispatch
                    var detectionDispatcher = new DetectionDispatcher();
                    detectionDispatcher.Dispatch(buildInformation);
                }
                finally
                {
                    //Unlock builds
                    _isAchievementDetectionRunning = false;
                }
            }
            return VSConstants.S_OK;
        }

        #region Unused events
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
