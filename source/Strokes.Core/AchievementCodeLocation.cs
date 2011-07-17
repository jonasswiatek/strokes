using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core
{
    public class AchievementCodeLocation
    {
        public AchievementCodeLocation()
        {
            From = new CodeLocation();
            To = new CodeLocation();            
        }
        
        public string FileName
        {
            get;
            set;
        }

        public CodeLocation From
        {
            get;
            set;
        }

        public CodeLocation To
        {
            get;
            set;
        }
    }

    public class CodeLocation
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
