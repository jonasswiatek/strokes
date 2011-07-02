using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using CodeCube.CSharpAchiever_Achiever_VSIX;
using CSharpAchiever.GUI.AchievementIndex;
using CSharpAchiever.VSX;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using Strokes.Core;
using Strokes.Core.Integration;
using Strokes.GUI;

namespace Strokes.VSX
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]

    [ProvideAutoLoad("{adfc4e64-0397-11d1-9f4e-00a0c911004f}")]
    
    [ProvideToolWindow(typeof(AchievementStatisticsToolWindow), Style = VsDockStyle.MDI)]
    [ProvideService(typeof(IAchevementLibraryService))]

    [Guid(GuidList.guidCSharpAchiever_Achiever_VSIXPkgString)]
    public sealed class StrokesVsxPackage : Package, IVsUpdateSolutionEvents2, IAchevementLibraryService
    {
        public StrokesVsxPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        private IVsSolutionBuildManager2 sbm = null;
        private uint updateSolutionEventsCookie;
        private DTE dte;

        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();
            
            // Add our command handlers for menu (commands must exist in the .vsct file)
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                // Create the command for the menu item.
                var menuCommandID = new CommandID(GuidList.guidCSharpAchiever_Achiever_VSIXCmdSet, (int)PkgCmdIDList.showAchievementIndex);
                var menuItem = new MenuCommand(MenuItemCallback, menuCommandID );
                mcs.AddCommand( menuItem );
            }
            
            //Subscribe to Build events
            // Get solution build manager 
            sbm = ServiceProvider.GlobalProvider.GetService(typeof(SVsSolutionBuildManager)) as IVsSolutionBuildManager2;
            if (sbm != null)
            {
                sbm.AdviseUpdateSolutionEvents(this, out updateSolutionEventsCookie);
            }

            dte = (DTE)GetService(typeof(DTE));

            //Promote the Achievement Library service
            var serviceContainer = (IServiceContainer)this;
            serviceContainer.AddService(typeof (IAchevementLibraryService), this, true);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            // Unadvise all events 
            if (sbm != null && updateSolutionEventsCookie != 0)
                sbm.UnadviseUpdateSolutionEvents(updateSolutionEventsCookie);
        } 

        #endregion

        /// <summary>
        /// Called by third party extensions to register their achievement assemblies.
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAchievementAssembly(Assembly assembly)
        {
            AchievementTracker.LoadAchievementsFromAssembly(assembly);
        }

        /// <summary>
        /// Called when the Tools -> C# Achievements menu is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            ShowAchievementPane(true);
        }

        private void ShowAchievementPane(bool activate)
        {
            var wnd = CreateToolWindow();
            var windowFrame = (IVsWindowFrame)wnd.Frame;
            if (activate)
                windowFrame.Show();
            else
                windowFrame.ShowNoActivate();
        }

        private AchievementStatisticsToolWindow CreateToolWindow()
        {
            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            var window = (AchievementStatisticsToolWindow)this.FindToolWindow(typeof(AchievementStatisticsToolWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("Can't show!");
            }

            return window;
        }

        /// <summary>
        /// This event is called when the solution has completed it's build
        /// </summary>
        /// <param name="fSucceeded"></param>
        /// <param name="fModified"></param>
        /// <param name="fCancelCommand"></param>
        /// <returns></returns>
        int IVsUpdateSolutionEvents.UpdateSolution_Done(int fSucceeded, int fModified, int fCancelCommand)
        {
            if (fSucceeded != 0)
            {
                var activeDocument = dte.ActiveDocument;
                if(activeDocument != null)
                {
                    var documentFile = activeDocument.FullName;
                    if (documentFile.EndsWith(".cs"))
                    {
                        DetectionDispatcher.Dispatch(new BuildInformation()
                        {
                            ActiveFile = documentFile
                        });
                    }
                }
            }
            return VSConstants.S_OK;
        }

        #region Unused events
        int IVsUpdateSolutionEvents.UpdateSolution_Begin(ref int pfCancelUpdate)
        {
            return VSConstants.S_OK;
        }

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
