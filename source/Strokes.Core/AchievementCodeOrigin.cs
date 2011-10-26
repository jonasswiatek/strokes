using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Strokes.Core
{
    public class AchievementCodeOrigin
    {
        public AchievementCodeOrigin()
        {
            From = new CodeAnchor();
            To = new CodeAnchor();            
        }
        
        public string GetCodeSnapshot()
        {
            if(File.Exists(FileName))
            {
                var lines = File.ReadLines(FileName);

                var fromLine = From.Line - 1;
                var toLine = To.Line - 1;

                var actualLines = lines.Skip(fromLine).Take(1 + (toLine - fromLine)).ToList();
                var firstLine = actualLines.FirstOrDefault();
                if (firstLine == null)
                    return string.Empty;

                var indentationLevel = Regex.Match(firstLine, @"^\s+").Length;

                return string.Join("\r\n", actualLines.Select(a => Regex.Replace(a, @"^\s{0," + indentationLevel + "}", "")));
            }
            return string.Empty;
        }

        public string FileName
        {
            get;
            set;
        }

        public CodeAnchor From
        {
            get;
            set;
        }

        public CodeAnchor To
        {
            get;
            set;
        }
    }

    public class CodeAnchor
    {
        public int Line
        {
            get;
            set;
        }
        
        public int Column
        {
            get;
            set;
        }
    }
}
