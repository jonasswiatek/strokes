using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Use the + operator", AchievementDescription = "Write an expression that uses the + operator", AchievementCategory = "Fundamentals")]
    public class PlusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.Add)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }


    [AchievementDescription("Use the - operator", AchievementDescription = "Write an expression that uses the - operator", AchievementCategory = "Fundamentals")]
    public class MinusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.Subtract)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescription("Use the * operator", AchievementDescription = "Write an expression that uses the * operator", AchievementCategory = "Fundamentals")]
    public class MultiplyOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.Multiply)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescription("Use the / operator", AchievementDescription = "Write an expression that uses the / operator", AchievementCategory = "Fundamentals")]
    public class DivideOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.Divide)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescription("Use the modulo operator", AchievementDescription = "Write an expression that uses the % operator", AchievementCategory = "Fundamentals")]
    public class ModuloOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Op == BinaryOperatorType.Modulus)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }
}