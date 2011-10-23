using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.NRefactory
{
    public static class NRefactoryHelpers
    {
        public static string GetShorthandOfType(this Type type)
        {
            if (type == null)
                return string.Empty;

            if(type == typeof(string))
            {
                return "string";
            }
            if (type == typeof(int))
            {
                return "int";
            }
            if (type == typeof(double))
            {
                return "double";
            }
            if (type == typeof(float))
            {
                return "float";
            }

            return string.Empty;
        }

        public static bool IsCallToType(this Expression expression, string fullTypeName)
        {
            var methodName = expression.GetIdentifier();
            var usings = expression.GetUsings();

            return usings.Any(a => (a + "." + methodName) == fullTypeName) || methodName == fullTypeName;
        }

        public static IEnumerable<VariableInitializer> GetVariablesOfInitializer<T>(this AstNode astNode)
        {
            var root = astNode.Parent;
            while (root != null)
            {
                if (root.Parent == null)
                    break;

                root = root.Parent;
            }

            var variableDeclarations = root.Descendants.OfType<VariableDeclarationStatement>();
            if (variableDeclarations.Any())
            {
                foreach (var variableDeclaration in variableDeclarations)
                {
                    foreach (var variable in variableDeclaration.Variables)
                    {
                        if (variable.Initializer is T)
                        {
                            yield return variable;
                        }
                    }
                }
            }
        }

        public static bool IsReferenceOfTypeFromScope(this Expression expression, string fullTypeName)
        {
            var current = expression.Parent;
            while(current != null)
            {
                var variableDeclarations = current.Descendants.OfType<VariableDeclarationStatement>();
                if(variableDeclarations.Any())
                {
                    foreach(var variableDeclaration in variableDeclarations)
                    {
                        foreach(var variable in variableDeclaration.Variables)
                        {
                            var objectCreation = variable.Initializer as ObjectCreateExpression;
                            if(objectCreation != null)
                            {
                                var typeName = objectCreation.Type.ToString();
                                var usings = objectCreation.GetUsings();

                                if (usings.Any(a => (a + "." + typeName) == fullTypeName))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                current = current.Parent;
            }
            return false;
        }

        public static IEnumerable<string> GetUsings(this AstNode astNode)
        {
            var result = new List<string>();

            var current = astNode.Parent;
            while(current != null)
            {
                var usings = current.Descendants.OfType<UsingDeclaration>();
                if(usings.Any())
                {
                    result.AddRange(usings.Select(a => a.Namespace));
                }

                current = current.Parent;
            }

            return result;
        }

        public static string GetIdentifier(this Expression expression)
        {
            var bla = expression.ToString();
            var result = new List<string>();

            var currentExpression = expression;
            while(currentExpression is MemberReferenceExpression)
            {
                var memberRef = currentExpression as MemberReferenceExpression;
                result.Add(memberRef.MemberName);

                currentExpression = memberRef.Target;
            }

            var identifier = currentExpression as IdentifierExpression;
            if(identifier != null)
            {
                result.Add(identifier.Identifier);
            }

            if (currentExpression is TypeReferenceExpression)
            {
                result.Add(currentExpression.ToString());
            }
            result.Reverse();
            return string.Join(".", result);
        }

        public static string GetCurrentNamespace(this AstNode astNode)
        {
            var result = new List<string>();

            var current = astNode;
            while (current != null)
            {
                var typeDeclaration = current as TypeDeclaration;
                if(typeDeclaration != null)
                {
                    result.Add(typeDeclaration.Name);
                }
                else
                {
                    var namespaceDeclaration = current as NamespaceDeclaration;
                    if(namespaceDeclaration != null)
                    {
                        result.AddRange(namespaceDeclaration.FullName.Split(".".ToCharArray()).Reverse());
                    }
                }

                current = current.Parent;
            }

            result.Reverse();

            return string.Join(".", result);
        }

        public static string GetFullName(this MemberType memberType)
        {
            var result = new List<string>();

            AstType current = memberType;
            while (current is SimpleType || current is MemberType)
            {
                var simple = current as SimpleType;
                if (simple != null)
                {
                    result.Add(simple.Identifier);
                    break;
                }

                var member = current as MemberType;
                result.Add(member.MemberName);
                current = member.Target;
            }
            result.Reverse();

            return string.Join(".", result);
        }

        public static bool Is<T>(this AstType astType)
            where T : struct
        {
            var type = typeof(T);

            if (type == typeof(short) || type == typeof(ushort))
                return IsShort(astType);
            else if (type == typeof(int) || type == typeof(uint))
                return IsInteger(astType);
            else if (type == typeof(long) || type == typeof(ulong))
                return IsLong(astType);
            else if (type == typeof(float))
                return IsFloat(astType);
            else if (type == typeof(double))
                return IsDouble(astType);
            else if (type == typeof(char))
                return IsChar(astType);
            else
                return false;
        }

        public static bool IsBoolean(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "bool" ||
                   typeName == "Boolean";
        }

        public static bool IsByte(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "byte" ||
                   typeName == "sbyte" ||
                   typeName == "Byte" ||
                   typeName == "SByte";
        }

        public static bool IsString(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "string" ||
                   typeName == "String";
        }

        public static bool IsShort(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "short" ||
                   typeName == "ushort" ||
                   typeName == "Int16" ||
                   typeName == "UInt16";
        }

        public static bool IsInteger(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "int" ||
                   typeName == "uint" ||
                   typeName == "Int32" ||
                   typeName == "UInt32";
        }

        public static bool IsLong(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "long" ||
                   typeName == "ulong" ||
                   typeName == "Int64" ||
                   typeName == "UInt64";
        }

        public static bool IsDouble(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "double" ||
                   typeName == "Double";
        }

        public static bool IsFloat(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "float";
        }

        public static bool IsChar(this AstType astType)
        {
            string typeName = astType.GetTypeName();
            return typeName == "char" ||
                   typeName == "Char";
        }

        public static string GetTypeName(this AstType astType)
        {
            if (astType is PrimitiveType)
            {
                return (astType as PrimitiveType).Keyword;
            }
            else if (astType is SimpleType)
            {
                return (astType as SimpleType).Identifier;
            }

            return string.Empty;
        }

        public static bool IsMemberReferenceOfType<TMemberType>(this MemberReferenceExpression expression)
        {
            var variations = new List<string>();
            if (typeof(TMemberType) == typeof(System.Int32))
            {
                variations = new List<string>() { "System.Int32", "Int32", "int" };
            }
            else if (typeof(TMemberType) == typeof(System.Double))
            {
                variations = new List<string>() { "System.Double", "Double", "double" };
            }
            else if (typeof(TMemberType) == typeof(System.Single))
            {
                variations = new List<string>() { "System.Single", "Single", "float" };
            }
            else if (typeof(TMemberType) == typeof(System.Char))
            {
                variations = new List<string>() { "System.Char", "Char", "char" };
            }

            return variations.Any(a => a == expression.Target.ToString());
        }
    }
}
