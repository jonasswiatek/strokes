using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.CSharpCodeGraph
{
    public class TypeName : CodeElement, ITypeNamed
    {
        public IList<string> TypeNames = new List<string>();

        public void AddTypeNameFromToken(Token token)
        {
            TypeNames.Add(token.val);
        }

        public virtual string FullName
        {
            get { return string.Join(".", TypeNames); }
        }
    }
}
