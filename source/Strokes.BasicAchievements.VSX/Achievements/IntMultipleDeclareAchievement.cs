using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare multiple integers in one statement", AchievementDescription = "Declare multiple integers in one go", AchievementCategory = "Basic Achievements")]
    public class IntMultipleDeclareAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            if (!File.Exists(detectionSession.BuildInformation.ActiveFile)) //Return out if the file doesn't exist (I don't think this will ever be the case - but better catch all 'em exceptions!
                return false;

            //Get the content of the file.
            var fileContent = File.ReadAllText(detectionSession.BuildInformation.ActiveFile);

            //Define a regular expression we can match against.
            var Regex = new Regex(@"int ( *?[\w-]+ *?)(, *?[\w-]+ *?)+;", RegexOptions.Multiline); 

            //If there is a match, this will return true and unlock the achievement.)
            return Regex.IsMatch(fileContent);
        }
    }
}
