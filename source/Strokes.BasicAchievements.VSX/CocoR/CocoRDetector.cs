using System;
using System.Collections.Generic;
using Strokes.BasicAchievements.CocoR.Grammars;

namespace Strokes.BasicAchievements.CocoR
{
    public class BasicCocoRDetector
    {
        //TODO: IMPLEMENT ACTUAL CACHING!

        public IEnumerable<Parser.BasicAchievement> DetectAchievements(string file)
        {
            var scanner = new Scanner(file);
            var parser = new Parser(scanner);
            parser.Parse();
            return parser.BasicAchievements.Keys;
        }

        public Parser GetParser(string file)
        {
            var scanner = new Scanner(file);
            var parser = new Parser(scanner);
            parser.Parse();
            return parser;
        }
    }
}