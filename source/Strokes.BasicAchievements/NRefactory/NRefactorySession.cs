using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactorySession : IDisposable
    {
        public IParser GetParser(string filename)
        {
            return ParserFactory.CreateParser(filename);
        }

        public void Dispose()
        {
        }
    }
}
