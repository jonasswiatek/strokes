namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class TypeDeclarationInfo
    {
        public string TypeName;
        public string Namespace;
        public TypeDeclarationKind DetinitionTypeDeclarationKind;
        public string Accessibility;
    }

    public enum TypeDeclarationKind
    {
        Class,
        Enum,
        Interface,
        Struct
    }
}
