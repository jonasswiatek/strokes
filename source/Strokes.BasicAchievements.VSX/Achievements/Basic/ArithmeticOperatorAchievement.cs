using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@PlusOperatorAchievementName",
        AchievementDescription = "@PlusOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
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


    [AchievementDescription("@MinusOperatorAchievementName",
        AchievementDescription = "@MinusOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
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

    [AchievementDescription("@MultiplyOperatorAchievementName",
        AchievementDescription = "@MultiplyOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
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

    [AchievementDescription("@DivideOperatorAchievementName",
        AchievementDescription = "@DivideOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
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

    [AchievementDescription("@ModuloOperatorAchievementName",
        AchievementDescription = "@ModuloOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
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