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
        
        public string GetCodeSnippet()
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

                var indentationSpaces = Regex.Match(firstLine, @"^\s+");
                var indentationLevel = indentationSpaces.Length;

                return string.Join("\r\n", actualLines.Select(a => a.Length > indentationLevel ? a.Substring(indentationLevel) : a));
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
