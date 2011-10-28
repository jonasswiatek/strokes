using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactoryContext
    {
        public IEnumerable<DeclarationInfo> CodebaseDeclarations
        {
            get;
            set;
        }

        public IList<SystemTypeInvocaton> InvokedSystemTypes { get; set; }

        public NRefactoryContext()
        {
        }
    }
}
