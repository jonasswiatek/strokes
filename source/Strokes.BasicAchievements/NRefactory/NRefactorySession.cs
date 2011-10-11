using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactorySession : IDisposable
    {
        private readonly IDictionary<string, IParser> parsers = new Dictionary<string, IParser>();

        public IParser GetParser(string filename)
        {
            if (parsers.ContainsKey(filename) == false)
                parsers.Add(filename, ParserFactory.CreateParser(filename));

            return parsers[filename];
        }

        public void Dispose()
        {
            foreach (var parser in parsers.Values)
                parser.Dispose();
        }
    }
}
