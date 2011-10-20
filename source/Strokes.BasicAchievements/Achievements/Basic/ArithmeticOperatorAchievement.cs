using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{AF6E17D7-9A43-4BF4-B47E-92E46E3B6865}", "@PlusOperatorAchievementName",
        AchievementDescription = "@PlusOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class PlusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Add)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }


    [AchievementDescriptor("{A45081C6-66AB-49FA-A388-54EBB850E8A9}", "@MinusOperatorAchievementName",
        AchievementDescription = "@MinusOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class MinusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Subtract)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescriptor("{C506DD84-FB53-4AB9-836E-62E410697DFB}", "@MultiplyOperatorAchievementName",
        AchievementDescription = "@MultiplyOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class MultiplyOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Multiply)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescriptor("{A1847340-4EF3-4B8F-816E-53138836864E}", "@DivideOperatorAchievementName",
        AchievementDescription = "@DivideOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class DivideOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Divide)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescriptor("{0CB8F81A-A95B-4DA3-95A4-F23AFAB4764D}", "@ModuloOperatorAchievementName",
        AchievementDescription = "@ModuloOperatorAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ModuloOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                if (binaryOperatorExpression.Operator == BinaryOperatorType.Modulus)
                    UnlockWith(binaryOperatorExpression);
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }
}