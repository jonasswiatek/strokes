using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.CSharpCodeGraph
{
    public interface ITypeNamed
    {
        void AddTypeNameFromToken(Token token);
    }
}
