using System.Collections.Generic;
using CSharpAchiever.Achievements.Basic.CocoR.Grammars;

namespace CSharpAchiever.Achievements.Basic.CocoR
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