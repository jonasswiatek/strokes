using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core
{
    public class AchievementCodeOrigin
    {
        public AchievementCodeOrigin()
        {
            From = new CodeAnchor();
            To = new CodeAnchor();            
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
