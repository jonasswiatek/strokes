using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;

namespace Strokes.BasicAchievements.NRefactory
{
    namespace Strokes.BasicAchievements.NRefactory
    {
        public class NRefactorySession : IDisposable
        {
            private readonly object _padLock = new object();
            private readonly IDictionary<string, IParser> _parsers = new Dictionary<string, IParser>();

            /// <summary>
            /// Creates a parser for the specified file. This parser is cached for this (one) detection session.
            /// </summary>
            /// <param name="filename"></param>
            /// <returns></returns>
            public IParser GetParser(string filename)
            {
                lock(_padLock) //Synchronize
                {
                    if (!_parsers.ContainsKey(filename))
                    {
                        var parser = ParserFactory.CreateParser(filename);
                        parser.Parse();

                        _parsers.Add(filename, parser);
                    }

                    return _parsers[filename];
                }
            }

            public void Dispose()
            {
                foreach (var parser in _parsers.Values)
                {
                    parser.Dispose();
                }
            }
        }
    }
}