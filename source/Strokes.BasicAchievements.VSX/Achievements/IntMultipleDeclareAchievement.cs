using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.BasicAchievements.CocoR;
using Strokes.BasicAchievements.CocoR.Grammars;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare multiple integers in one statement", AchievementDescription = "Declare multiple integers in one go", AchievementCategory = "Basic Achievements")]
    public class IntMultipleDeclareAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var cocoRDetector = detectionSession.GetSessionObjectOfType<BasicCocoRDetector>(); //Gets a cached BasicCocoRDetector instance.
            var parser = cocoRDetector.GetParser(detectionSession.BuildInformation.ActiveFile); //Gets a parser for the document.

            return parser.Graph.DeclaredFields.Any(a => a.FieldType == "int" && a.DeclarationCount > 1); //Any int declarations that declares more than one int.
        }
    }
}
