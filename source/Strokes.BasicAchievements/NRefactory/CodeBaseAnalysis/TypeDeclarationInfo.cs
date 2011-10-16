namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class TypeDeclarationInfo
    {
        public string TypeName
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public TypeDeclarationKind DetinitionTypeDeclarationKind
        {
            get;
            set;
        }

        public string Accessibility
        {
            get;
            set;
        }
    }

    public enum TypeDeclarationKind
    {
        Class,
        Enum,
        Interface,
        Struct
    }
}
