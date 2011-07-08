using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.Core
{
    public class AchievementCodeLocation
    {
        public string FileName;
        public CodeLocation From = new CodeLocation();
        public CodeLocation To = new CodeLocation();
    }

    public class CodeLocation
    {
        public int Line;
        public int Column;
    }
}
