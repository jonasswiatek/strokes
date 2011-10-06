using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using CSharpAchiever.VSX;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Strokes.BasicAchievements;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Integration;
using Strokes.Data;
using Strokes.GUI;
using Strokes.VSX.Trackers;

namespace Strokes.VSX
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideAutoLoad("{adfc4e64-0397-11d1-9f4e-00a0c911004f}")] //This is UICONTEXT_NoSolution - meaning Strokes will start together with Visual Studio regardless of which type of project is loaded.
    [ProvideToolWindow(typeof(AchievementStatisticsToolWindow), Style = VsDockStyle.MDI)]
    [ProvideService(typeof(IAchevementLibraryService))]
    [Guid(GuidList.guidCSharpAchiever_Achiever_VSIXPkgString)]
    public sealed class StrokesVsxPackage : PackageEx, IAchevementLibraryService
    {
        /// <summary>
        /// Cookie that allows the package to stop listening for build events.
        /// </summary>
        private uint updateSolutionEventsCookie = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="StrokesVsxPackage"/> class.
        /// </summary>
        public StrokesVsxPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        /// <summary>
        /// Registers a achievement assembly.
        /// </summary>
        /// <param name="assembly">The assembly to register.</param>
        public void RegisterAchievementAssembly(Assembly assembly)
        {
            GetService<AchievementDescriptorRepository>().LoadFromAssembly(assembly);
        }

        /// <summary>
        /// Gets the environment's status bar.
        /// </summary>
        private IVsStatusbar StatusBar
        {
            get
            {
                return GetService<SVsStatusbar>() as IVsStatusbar;
            }
        }

        /// <summary>
        /// Gets the solution's build manager.
        /// </summary>
        private IVsSolutionBuildManager2 SolutionBuildManager
        {
            get
            {
                return ServiceProvider.GlobalProvider.GetService<SVsSolutionBuildManager>() as IVsSolutionBuildManager2;
            }
        }

        /// <summary>
        /// Gets the top-level object in the Visual Studio automation object model.
        /// </summary>
        private DTE DTE
        {
            get
            {
                return GetService<DTE>();
            }
        }

        /// <summary>
        /// Gets the service used to add handlers for menu commands and to define verbs.
        /// </summary>
        private OleMenuCommandService MenuService
        {
            get
            {
                return GetService<IMenuCommandService>() as OleMenuCommandService;
            }
        }

        /// <summary>
        /// Called when the VSPackage is loaded by Visual Studio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));

            base.Initialize();

            if (MenuService != null)
            {
                var menuCommandID = new CommandID(
                    GuidList.guidCSharpAchiever_Achiever_VSIXCmdSet,
                    (int)PkgCmdIDList.showAchievementIndex);

                var menuItem = new MenuCommand(MenuItemCallback, menuCommandID);

                MenuService.AddCommand(menuItem);
            }

            if (SolutionBuildManager != null)
            {
                var buildTracker = new BuildTracker(DTE);

                SolutionBuildManager.AdviseUpdateSolutionEvents(buildTracker, out updateSolutionEventsCookie);
            }

            AddService<IAchevementLibraryService>(this, true);
            AddService<AchievementDescriptorRepository>(new AchievementDescriptorRepository(), true);

            RegisterAchievementAssembly(typeof(NRefactoryAchievement).Assembly);

            GuiInitializer.Initialize();

            AchievementContext.AchievementClicked += AchievementContext_AchievementClicked;
            DetectionDispatcher.DetectionCompleted += DetectionDispatcher_DetectionCompleted;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; 
        ///     <c>false</c> to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (SolutionBuildManager != null && updateSolutionEventsCookie != 0)
                SolutionBuildManager.UnadviseUpdateSolutionEvents(updateSolutionEventsCookie);
        }

        /// <summary>
        /// Handles the DetectionCompleted event of the DetectionDispatcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///     The <see cref="Strokes.VSX.DetectionCompletedEventArgs"/> instance containing the event data.
        /// </param>
        private void DetectionDispatcher_DetectionCompleted(object sender, DetectionCompletedEventArgs e)
        {
            StatusBar.SetText(string.Format("{0} achievements tested in {1} milliseconds",
                e.AchievementsTested, e.ElapsedMilliseconds));
        }

        /// <summary>
        /// Handles the AchievementClicked event of the AchievementContext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">
        ///     The <see cref="Strokes.Core.AchievementClickedEventArgs"/> instance containing the event data.
        /// </param>
        private void AchievementContext_AchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            // TODO: Make this also ensure that the lines that unlocks the achievement 
            // becomes visible within the ActiveDocument (scroll to it).
            DTE.ItemOperations.OpenFile(args.AchievementDescriptor.CodeLocation.FileName, EnvDTE.Constants.vsViewKindCode);
        }

        /// <summary>
        /// Menus the item callback.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            ShowAchievementPane(true);
        }

        /// <summary>
        /// Shows the achievement pane.
        /// </summary>
        /// <param name="activate">
        ///     <c>true</c> to show and makes the achievement pane the active window.
        ///     <c>true</c> to show without making the achievement pane the active window.
        /// </param>
        private void ShowAchievementPane(bool activate)
        {
            var window = FindToolWindow<AchievementStatisticsToolWindow>(0, true);
            var windowFrame = window.Frame as IVsWindowFrame;

            if (activate)
                windowFrame.Show();
            else
                windowFrame.ShowNoActivate();
        }
    }
}
