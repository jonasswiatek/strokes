using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{69259D8F-18D3-416E-AC14-0EB48AA79D6B}", "@PlusPlusOperatorAchievementName",
        AchievementDescription = "@PlusPlusOperatorAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-US/library/36x43w8w(v=VS.100).aspx",
        AchievementCategory = "@Fundamentals")]
    public class PlusPlusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data)
            {
                if (unaryOperatorExpression.Operator == UnaryOperatorType.PostIncrement || unaryOperatorExpression.Operator == UnaryOperatorType.Increment)
                    UnlockWith(unaryOperatorExpression);
                return base.VisitUnaryOperatorExpression(unaryOperatorExpression, data);
            }
        }
    }

    [AchievementDescriptor("{9D1CF4C5-9AA8-4E1F-B4D8-241357A8BFE3}", "@MinusMinusOperatorAchievementName",
        AchievementDescription = "@MinusMinusOperatorAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/wc3z3k8c.aspx",
        AchievementCategory = "@Fundamentals")]
    public class MinusMinusOperatorAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression, object data)
            {
                if (unaryOperatorExpression.Operator == UnaryOperatorType.PostDecrement || unaryOperatorExpression.Operator == UnaryOperatorType.Decrement)
                    UnlockWith(unaryOperatorExpression);
                return base.VisitUnaryOperatorExpression(unaryOperatorExpression, data);
            }
        }
    }




}