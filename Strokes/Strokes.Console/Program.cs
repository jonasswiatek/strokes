using System;
using System.Windows;
using CSharpAchiever.AchievementDispatcher;
using CSharpAchiever.Core;
using CSharpAchiever.GUI.AchievementIndex;

namespace CSharpAchiever.Console
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