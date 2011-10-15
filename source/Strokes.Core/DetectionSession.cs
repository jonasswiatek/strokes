using System;
using System.Linq;
using System.Collections.Generic;
using ICSharpCode.NRefactory;

namespace Strokes.Core
{
    public class DetectionSession : IDisposable
    {
        public DetectionSession(BuildInformation buildInformation)
        {
            BuildInformation = buildInformation;

            Parser = ParserFactory.CreateParser(buildInformation.ActiveFile);
            Parser.Parse();
        }

        public BuildInformation BuildInformation
        {
            get;
            private set;
        }

        public IParser Parser
        {
            get;
            set;
        }

        public void Dispose()
        {
            Parser.Dispose();
        }
    }
}
