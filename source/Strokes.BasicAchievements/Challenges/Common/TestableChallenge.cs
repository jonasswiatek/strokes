using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core.Service;

namespace Strokes.BasicAchievements.Challenges.Common
{
    public abstract class TestableChallenge<TInterface, TRunner> : ChallengeBase where TInterface : class where TRunner : class
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor(() => TestChallenge(statisAnalysisSession));
        }

        protected virtual bool TestChallenge(StatisAnalysisSession statisAnalysisSession)
        {
            if (string.IsNullOrEmpty(statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory))
            {
                return false;
            }

            var dlls = new List<string>();

            // Some directory listing hackery
            dlls.AddRange(GetOutputFiles(statisAnalysisSession, "*.dll"));
            dlls.AddRange(GetOutputFiles(statisAnalysisSession, "*.exe"));

            // If the Strokes.Challenges.Student-dll isn't in the build output, 
            // this project can with certainty be said to not be a challenge-solve attempt.
            if (!dlls.Any(dll => dll.Contains("Strokes.Challenges.dll")))
                return false;

            var challengeRunner = typeof (TRunner).FullName;

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            processStartInfo.FileName = Path.Combine(processStartInfo.WorkingDirectory, "Strokes.ChallengeRunner.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = string.Join(" ", statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory.Replace(" ", "*"), challengeRunner);

            var process = Process.Start(processStartInfo);

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            return output == "OK";
        }

        private static IEnumerable<string> GetOutputFiles(StatisAnalysisSession statisAnalysisSession, string searchPattern)
        {
            var directory = statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory;

            return Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories)
                            .Where(file => file.IndexOf("vshost") < 0);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly Func<bool> _test;

            public Visitor(Func<bool> test)
            {
                _test = test;
            }

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                var tName = typeof (TInterface).Name;
                if (typeDeclaration.ClassType == ClassType.Class && typeDeclaration.BaseTypes.OfType<SimpleType>().Any(a => a.Identifier == tName))
                {
                    if(_test())
                    {
                        IsAchievementUnlocked = true;
                    }
                }
                
                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}