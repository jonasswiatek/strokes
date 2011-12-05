using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Challenges;
using Strokes.Core.Service;

namespace Strokes.BasicAchievements.Challenges.Common
{
    public abstract class TestableChallenge<TInterface, TRunner> : ChallengeBase
        where TInterface : class
        where TRunner : class
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor(() => TestChallenge(statisAnalysisSession));
        }

        protected virtual TestableChallengeResult TestChallenge(StatisAnalysisSession statisAnalysisSession)
        {
            if (string.IsNullOrEmpty(statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory))
            {
                return null;
            }

            var dlls = new List<string>();

            // Some directory listing hackery
            dlls.AddRange(GetOutputFiles(statisAnalysisSession, "*.dll"));
            dlls.AddRange(GetOutputFiles(statisAnalysisSession, "*.exe"));

            var challengeRunner = typeof(TRunner).FullName;

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            processStartInfo.FileName = Path.Combine(processStartInfo.WorkingDirectory, "Strokes.ChallengeRunner.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = string.Join(" ", 
                statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory.Replace(" ", "*"), challengeRunner
            );

            var process = Process.Start(processStartInfo);
            var error = process.StandardError.ReadToEnd();

            // Create an XML Serializer so we can read a testable challenge result from the process' standard output.
            var serializer = new XmlSerializer(typeof(TestableChallengeResult));
            try
            {
                return (TestableChallengeResult)serializer.Deserialize(process.StandardOutput);
            }
            catch
            {
                return null;
            }
        }

        private static IEnumerable<string> GetOutputFiles(StatisAnalysisSession statisAnalysisSession, string searchPattern)
        {
            var directory = statisAnalysisSession.StaticAnalysisManifest.ActiveProjectOutputDirectory;

            return Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories)
                            .Where(file => file.IndexOf("vshost") < 0);
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly Func<TestableChallengeResult> _test;

            public Visitor(Func<TestableChallengeResult> test)
            {
                _test = test;
            }

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                var tName = typeof(TInterface).Name;
                if (typeDeclaration.ClassType == ClassType.Class && typeDeclaration.BaseTypes.OfType<SimpleType>().Any(a => a.Identifier == tName))
                {
                    var result = _test();

                    // Test did not yield any meaningful result. This is only really likely to occur 
                    // during debugging with Strokes.Console of if something has broken.

                    if (result == null)
                    {
                        return base.VisitTypeDeclaration(typeDeclaration, data);
                    }

                    if (result.IsPassed)
                    {
                        IsAchievementUnlocked = true;
                    }
                    else if (string.IsNullOrEmpty(result.Error))
                    {
                        // Partially passed achievement.
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}