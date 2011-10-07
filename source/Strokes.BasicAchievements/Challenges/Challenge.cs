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
        protected string ChallengeRunner;
        public Challenge(string challengeRunner)
        {
            ChallengeRunner = challengeRunner;
        }

        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            if (string.IsNullOrEmpty(detectionSession.BuildInformation.ActiveProjectOutputDirectory))
                return false;

            var dlls = new List<string>();

            //Some directory listing hackery
            dlls.AddRange(Directory.GetFiles(detectionSession.BuildInformation.ActiveProjectOutputDirectory, "*.dll", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));
            dlls.AddRange(Directory.GetFiles(detectionSession.BuildInformation.ActiveProjectOutputDirectory, "*.exe", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));

            //If the Strokes.Challenges.Student-dll isn't in the build output, this project can with certainty be said to not be a challenge-solve attempt.
            if (!dlls.Any(dll => dll.Contains("Strokes.Challenges.dll")))
                return false;

            var processStartInfo = new ProcessStartInfo ();
            processStartInfo.UseShellExecute = false;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            processStartInfo.FileName = Path.Combine(processStartInfo.WorkingDirectory, "Strokes.ChallengeRunner.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.Arguments = string.Join(" ", detectionSession.BuildInformation.ActiveProjectOutputDirectory.Replace(" ", "*"), ChallengeRunner);

            var process = Process.Start(processStartInfo);

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            return output == "OK";
        }
    }
}