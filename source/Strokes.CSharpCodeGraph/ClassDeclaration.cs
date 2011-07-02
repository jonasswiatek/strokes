using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strokes.CSharpCodeGraph
{
    public class ClassDeclaration : TypeDeclaration
    {
        public ClassDeclaration(IEnumerable<Modifier> modifiers) : base(modifiers)
        {
        }

        public ClassDeclaration(IEnumerable<Modifier> modifiers, Namespace @namespace) : base(modifiers, @namespace)
        {
        }

        public override string FullName
        {
            get
            {
                if(Namespace != null)
                {
                    return Namespace.FullName + "." + base.FullName;
                }
                return base.FullName;
            }
        }
    }
}
