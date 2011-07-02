using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;
using Strokes.CSharpCodeGraph.CodeElements;
using Strokes.CSharpCodeGraph.CodeElements.TypeDeclarations;

namespace Strokes.CSharpCodeGraph
{
    public class Namespace : NamedType
    {
        public IList<TypeDeclaration> TypeDeclarations = new List<TypeDeclaration>();
    }
}