using System.Collections.Generic;

namespace Strokes.CSharpCodeGraph.CodeElements.TypeDeclarations
{
    public class TypeDeclaration : NamedType
    {
        public IEnumerable<Modifier> Modifiers;
        public IList<NamedType> Interfaces = new List<NamedType>();

        public TypeDeclaration(IEnumerable<Modifier> modifiers)
        {
            Modifiers = modifiers;
        }
    }
}
