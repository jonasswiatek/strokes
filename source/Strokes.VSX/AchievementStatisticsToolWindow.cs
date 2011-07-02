using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using System.Windows.Controls;
using System.Reflection;
using EnvDTE;
using Strokes.GUI;

namespace Strokes.VSX
{
    [Guid("860da2e9-60ef-4698-b539-ff847e203824")]
    public class AchievementStatisticsToolWindow : ToolWindowPane
    {
        private DocumentEvents _documentEvents;
        private SolutionEvents _solutionEvents;
        private WindowEvents _windowEvents;

        public AchievementStatisticsToolWindow() : base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = "Achievement Statistics";
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 0;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.

            base.Content = new AchievementPane();
        }
    }
}
