using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.Achievements
{
    internal static class ReturnTypeHelper
    {
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
    }
}
