using System.Collections.Generic;
using Strokes.BasicAchievements.CocoR.Grammars;

namespace Strokes.BasicAchievements.CocoR
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