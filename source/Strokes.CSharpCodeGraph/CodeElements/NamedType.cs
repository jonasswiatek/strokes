using System.Collections.Generic;
using Strokes.CSharpCodeGraph.CocoR.Grammars;
using Strokes.CSharpCodeGraph.Interfaces;

namespace Strokes.CSharpCodeGraph.CodeElements
{
    public class NamedType : CodeElement, INamedType
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