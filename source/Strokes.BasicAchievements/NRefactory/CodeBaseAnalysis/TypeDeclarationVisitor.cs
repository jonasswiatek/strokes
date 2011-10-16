using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;

namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class TypeDeclarationVisitor : AbstractAstVisitor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TypeDeclarationVisitor"/> class.
        /// </summary>
        public TypeDeclarationVisitor()
        {
            TypeDeclarations = new List<TypeDeclarationInfo>();
        }

        public IList<TypeDeclarationInfo> TypeDeclarations
        {
            get;
            set;
        }

        public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            var typeName = typeDeclaration.Name;
            TypeDeclarationKind typeDeclarationKind;
            switch (typeDeclaration.Type)
            {
                case ClassType.Class:
                    typeDeclarationKind = TypeDeclarationKind.Class;
                    break;
                case ClassType.Enum:
                    typeDeclarationKind = TypeDeclarationKind.Enum;
                    break;
                case ClassType.Interface:
                    typeDeclarationKind = TypeDeclarationKind.Interface;
                    break;
                case ClassType.Struct:
                    typeDeclarationKind = TypeDeclarationKind.Struct;
                    break;
                default:
                    typeDeclarationKind = TypeDeclarationKind.Class;
                    break;
            }

            var typeDeclarationNamespace = "";
            if (typeDeclaration.Parent != null && typeDeclaration.Parent is NamespaceDeclaration)
            {
                var namespaceDeclaration = (NamespaceDeclaration)typeDeclaration.Parent;
                typeDeclarationNamespace = namespaceDeclaration.Name;
            }

            TypeDeclarations.Add(new TypeDeclarationInfo
            {
                Accessibility = typeDeclaration.Modifier.ToString(),
                TypeName = typeName,
                Namespace = typeDeclarationNamespace,
                DetinitionTypeDeclarationKind = typeDeclarationKind
            });

            return base.VisitTypeDeclaration(typeDeclaration, data);
        }
    }
}
