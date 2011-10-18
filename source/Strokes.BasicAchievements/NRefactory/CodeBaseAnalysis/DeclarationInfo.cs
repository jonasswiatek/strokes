using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class DeclarationInfo
    {
        public string Name
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public string TypeName { get; set; }
        public List<string> PossibleTypeNamespaces { get; set; }

        public Expression Initializer { get; set; }

        public TypeDeclarationKind DeclarationClassType
        {
            get;
            set;
        }

        public string Accessibility
        {
            get;
            set;
        }

        public string FullName
        {
            get { return Namespace + "." + Name; }
        }

        public DeclarationInfo()
        {
            PossibleTypeNamespaces = new List<string>();
        }

        public bool IsType(string fullTypeName)
        {
            return PossibleTypeNamespaces.Any(a => (a + "." + TypeName) == fullTypeName);
        }
    }

    public enum TypeDeclarationKind
    {
        Class,
        Enum,
        Interface,
        Struct,
        Event,
        Field
    }
}
