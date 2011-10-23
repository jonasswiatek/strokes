using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;

namespace Strokes.Core.Integration
{
    [Guid("fafafdfb-60f3-47e4-b38c-1bae05b44240")]
    public interface IAchievementLibraryService
    {
        void RegisterAchievementAssembly(Assembly assembly);
    }
}