using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize int", AchievementDescription = "Declare and initialize int in one statement", AchievementCategory = "Basic Achievements")]
    public class IntDeclareAndInitializeAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            if (!File.Exists(detectionSession.BuildInformation.ActiveFile)) //Return out if the file doesn't exist (I don't think this will ever be the case - but better catch all 'em exceptions!
                return false;

            //Get the content of the file.
            var fileContent = File.ReadAllText(detectionSession.BuildInformation.ActiveFile);

            //Define a regular expression we can match against.
            var Regex = new Regex(@"int ([\w-]+) *?= *?[0-9];", RegexOptions.Multiline); //Will also detect for (int = 0 ...Not sure if we want that as an unlocked achievement?

            //If there is a match, this will return true and unlock the achievement.)
            return Regex.IsMatch(fileContent);
        }
    }
}
