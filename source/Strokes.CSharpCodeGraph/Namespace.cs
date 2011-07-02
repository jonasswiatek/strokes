using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.CSharpCodeGraph
{
    public class Namespace : TypeName
    {
        public IList<TypeDeclaration> TypeDeclarations = new List<TypeDeclaration>();
    }
}