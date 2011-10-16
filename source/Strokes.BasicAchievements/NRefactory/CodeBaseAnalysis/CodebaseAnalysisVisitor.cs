using System;
using System.Linq;
using System.Collections.Generic;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class CodebaseAnalysisVisitor : DepthFirstAstVisitor<object, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CodebaseAnalysisVisitor"/> class.
        /// </summary>
        public CodebaseAnalysisVisitor()
        {
            TypeDeclarations = new List<DeclarationInfo>();
        }

        /// <summary>
        /// Gets or sets the type declarations.
        /// </summary>
        public List<DeclarationInfo> TypeDeclarations
        {
            get;
            set;
        }

        public override object VisitEventDeclaration(EventDeclaration eventDeclaration, object data)
        {
            foreach(var eventVariable in eventDeclaration.Variables)
            {
                TypeDeclarations.Add(new DeclarationInfo()
                                         {
                                             Accessibility = eventDeclaration.Modifiers.ToString(),
                                             DeclarationClassType = TypeDeclarationKind.Event,
                                             Namespace = eventVariable.GetCurrentNamespace(),
                                             Name = eventVariable.Name
                                         });
            }
            return base.VisitEventDeclaration(eventDeclaration, data);
        }

        public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
        {
            var declarations = fieldDeclaration.Variables.Select(a => a.Name);
            var usings = fieldDeclaration.GetUsings();

            var declarationInfos = declarations.Select(a => new DeclarationInfo()
                                                                {
                                                                    DeclarationClassType = TypeDeclarationKind.Field,
                                                                    Name = a,
                                                                    TypeName = fieldDeclaration.ReturnType.ToString(),
                                                                    PossibleTypeNamespaces = usings.ToList(),
                                                                    Namespace = fieldDeclaration.GetCurrentNamespace()
                                                                });
            TypeDeclarations.AddRange(declarationInfos);

            return base.VisitFieldDeclaration(fieldDeclaration, data);
        }

        public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            var typeName = typeDeclaration.Name;
            TypeDeclarationKind typeDeclarationKind;
            switch(typeDeclaration.ClassType)
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

            var typeDeclarationNamespace = typeDeclaration.Parent.GetCurrentNamespace();

            TypeDeclarations.Add(new DeclarationInfo
                                     {
                                         Accessibility = typeDeclaration.Modifiers.ToString(),
                                         Name = typeName,
                                         Namespace = typeDeclarationNamespace,
                                         DeclarationClassType = typeDeclarationKind
                                     });

            return base.VisitTypeDeclaration(typeDeclaration, data);
        }
    }
}
