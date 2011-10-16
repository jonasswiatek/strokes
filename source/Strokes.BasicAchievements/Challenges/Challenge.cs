using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    public abstract class Challenge : AchievementBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Challenge"/> class.
        /// </summary>
        /// <param name="challengeRunner">The path to the Challenge Runner.</param>
        public Challenge(string challengeRunner)
        {
            ChallengeRunner = challengeRunner;
        }

        /// <summary>
        /// Gets or sets the path to the Challenge Runner.
        /// </summary>
        protected string ChallengeRunner
        {
            get;
            set;
        }

        /// <summary>
        /// Detects the achievement.
        /// </summary>
        /// <param name="detectionSession">The detection session.</param>
        /// <returns><c>true</c> if the ChallengeRunner returned 'OK'; otherwise <c>false</c>.</returns>
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            if (string.IsNullOrEmpty(detectionSession.BuildInformation.ActiveProjectOutputDirectory))
            {
                return false;
            }

            var dlls = new List<string>();

            // Some directory listing hackery
            dlls.AddRange(GetOutputFiles(detectionSession, "*.dll"));
            dlls.AddRange(GetOutputFiles(detectionSession, "*.exe"));

            // If the Strokes.Challenges.Student-dll isn't in the build output, 
            // this project can with certainty be said to not be a challenge-solve attempt.
            if (!dlls.Any(dll => dll.Contains("Strokes.Challenges.dll")))
                return false;

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            processStartInfo.FileName = Path.Combine(processStartInfo.WorkingDirectory, "Strokes.ChallengeRunner.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = string.Join(" ",
                detectionSession.BuildInformation.ActiveProjectOutputDirectory.Replace(" ", "*"), ChallengeRunner);

            var process = Process.Start(processStartInfo);

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            return output == "OK";
        }

        /// <summary>
        /// Gets the output files for a given session, filtered by the given search pattern.
        /// </summary>
        /// <param name="detectionSession">The detection session.</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <returns>A list of file paths.</returns>
        private static IEnumerable<string> GetOutputFiles(DetectionSession detectionSession, string searchPattern)
        {
            var directory = detectionSession.BuildInformation.ActiveProjectOutputDirectory;

            return Directory.GetFiles(directory, searchPattern, SearchOption.AllDirectories)
                            .Where(file => file.IndexOf("vshost") < 0);
        }
    }
}