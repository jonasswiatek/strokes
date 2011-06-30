using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.BasicAchievements.CocoR.Grammars;

namespace Strokes.BasicAchievements.CocoR
{
    public class CodeGraph
    {
        public Dictionary<BasicAchievement, CodeAnchor> BasicAchievements = new Dictionary<BasicAchievement, CodeAnchor>();
        public List<DeclaredField> DeclaredFields = new List<DeclaredField>();
        public List<DeclaredProperty> DeclaredProperties = new List<DeclaredProperty>();
        public List<Constant> DeclaredConstants = new List<Constant>();

        private Initializable lastInitializable = null;

        public void RegisterBasicAchievement(BasicAchievement achievement)
        {
            if (!BasicAchievements.ContainsKey(achievement))
            {
                BasicAchievements.Add(achievement, new CodeAnchor ());
            }
        }

        public void RegisterDeclaredField(Token token, IEnumerable<Modifier> modifiers)
        {
            System.Diagnostics.Debug.WriteLine("Field: " + token.val);
            var field = new DeclaredField()
            {
                FieldType = token.val,
                Token = token,
                Modifiers = modifiers
            };

            DeclaredFields.Add(field);
            lastInitializable = field;
        }

        public void RegisterDeclaredProperty(Token token, IEnumerable<Modifier> modifiers)
        {
            System.Diagnostics.Debug.WriteLine("Property: " + token.val);
            DeclaredProperties.Add(new DeclaredProperty()
            {
                PropertyType = token.val,
                Token = token,
                Modifiers = modifiers
            });
        }

        public void RegisterConstant(Token token, IEnumerable<Modifier> modifiers)
        {
            System.Diagnostics.Debug.WriteLine("Constant: " + token.val);
            DeclaredConstants.Add(new Constant()
            {
                FieldType = token.val,
                Token = token,
                Modifiers = modifiers
            });
        }

        public void LastPropertyHadPrivateSetter()
        {
            System.Diagnostics.Debug.WriteLine("LastPropertyHadPrivateSetter");
            DeclaredProperties[DeclaredProperties.Count - 1].HasPrivateSetter = true;
        }

        public void BumpLastFieldDeclarationsCount()
        {
            System.Diagnostics.Debug.WriteLine("BumpLastFieldDeclarationsCount");
            DeclaredFields[DeclaredFields.Count - 1].DeclarationCount++;
        }

        public void BumpLastConstantDeclarationsCount()
        {
            System.Diagnostics.Debug.WriteLine("BumpLastConstantDeclarationsCount");
            DeclaredConstants[DeclaredConstants.Count - 1].DeclarationCount++;
        }

        public void VariableInitialized(Token token)
        {
            System.Diagnostics.Debug.WriteLine("VariableInitialized: " + token.line);

            //TODO: This shouldn't be null at all. If it does, then I've been sloppy. I'm sloppy right now!
            if (lastInitializable != null)
                lastInitializable.IsInitialized = true;

            lastInitializable = null;
        }

        public class Initializable
        {
            public bool IsInitialized;
        }

        public class DeclaredField : Initializable
        {
            public string FieldType;
            public string FieldKind;
            public Token Token;
            public int DeclarationCount = 1;
            public IEnumerable<Modifier> Modifiers;
        }

        public class Constant
        {
            public string FieldType;
            public string FieldKind;
            public Token Token;
            public int DeclarationCount = 1;
            public IEnumerable<Modifier> Modifiers;
        }

        public class DeclaredProperty
        {
            public string PropertyType;
            public string PropertyKind;
            public Token Token;
            public bool HasPrivateSetter;
            public IEnumerable<Modifier> Modifiers;
        }
    }

    public enum BasicAchievement
    {
        PrivateSetter,

        EnumInitializer,

        QueryExpression,
        JoinExpression,
        LambdaExpression,

        AnonymousObject,
        ParamsParameter,

        ForLoop,
        ForeachLoop,
        WhileLoop,
        DoWhileLoop,

        TryCatchStatement,
        TryCatchFinallyStatement,
        TryFinallyStatment
    }

    public enum Modifier
    {
        None,
        Internal,
        Private,
        Protected,
        Public,
        Static,
        New,
        Unsafe,
        Readonly,
        Volatile
    }

    public struct CodeAnchor
    {
        public int Line;
        public int Column;
    }
}
