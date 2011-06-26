using System.Collections.Generic;
using Strokes.Achievements.Basic.CocoR.Grammars;

namespace Strokes.Achievements.Basic.CocoR
{
    public class BasicCocoRDetector
    {
        public IEnumerable<Parser.BasicAchievement> DetectAchievements(string file)
        {
            var scanner = new Scanner(file);
            var parser = new Parser(scanner);
            parser.Parse();
            return parser.BasicAchievements.Keys;
        }
    }
}