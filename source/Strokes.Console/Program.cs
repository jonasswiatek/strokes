using System;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using Strokes.AchievementDispatcher;
using Strokes.Core;

namespace Strokes.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var buildInfo = new BuildInformation()
            {
                ActiveFile = System.IO.Path.GetFullPath("TestFile.cs")
            };

            var dispatched = DetectionDispatcher.Dispatch(buildInfo);

            if (!dispatched)
            {
                new Application().Run(new AchievementIndex());
            }
        }
    }
}