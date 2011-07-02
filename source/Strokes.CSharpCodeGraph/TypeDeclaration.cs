using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.CSharpCodeGraph
{
    public class TypeDeclaration : TypeName
    {
        public Namespace Namespace;
        public IEnumerable<Modifier> Modifiers;

        public TypeDeclaration(IEnumerable<Modifier> modifiers)
        {
            Modifiers = modifiers;
        }

        public TypeDeclaration(IEnumerable<Modifier> modifiers, Namespace @namespace) : this(modifiers)
        {
            Namespace = @namespace;
        }
    }
}
