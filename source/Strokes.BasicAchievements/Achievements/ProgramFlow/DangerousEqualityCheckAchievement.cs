using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{463CA967-E431-4479-AE4C-2F318C00DD09}", "@DangerousEqualityCheckAchievementName",
        AchievementDescription = "@DangerousEqualityCheckAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class DangerousEqualityCheckAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private readonly List<string> doublefloatvariables = new List<string>();

            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                bool leftdangerous = false;
                bool rightdangerous = false;

                if (binaryOperatorExpression.Operator == BinaryOperatorType.Equality)
                {
                    if (binaryOperatorExpression.Left is PrimitiveExpression)
                    {
                        PrimitiveExpression prim = (PrimitiveExpression)binaryOperatorExpression.Left;
                        if (prim.Value.GetType() == typeof(double) ||
                            prim.Value.GetType() == typeof(float) ||
                            prim.Value.GetType() == typeof(decimal))
                        {
                            leftdangerous = true;
                        }
                    }
                    else if (binaryOperatorExpression.Left is IdentifierExpression)
                    {
                        IdentifierExpression idexpr = (IdentifierExpression)binaryOperatorExpression.Left;
                        if (doublefloatvariables.Contains(idexpr.Identifier))
                        {
                            leftdangerous = true;
                        }
                    }

                    if (binaryOperatorExpression.Right is PrimitiveExpression)
                    {
                        PrimitiveExpression prim = (PrimitiveExpression)binaryOperatorExpression.Right;
                        if (prim.Value.GetType() == typeof(double) ||
                            prim.Value.GetType() == typeof(float) ||
                            prim.Value.GetType() == typeof(decimal))
                        {
                            rightdangerous = true;
                        }
                    }
                    else if (binaryOperatorExpression.Right is IdentifierExpression)
                    {
                        IdentifierExpression idexpr = (IdentifierExpression)binaryOperatorExpression.Right;
                        if (doublefloatvariables.Contains(idexpr.Identifier))
                        {
                            rightdangerous = true;
                        }
                    }

                    if (leftdangerous || rightdangerous)
                    {
                        UnlockWith(binaryOperatorExpression);
                    }
                }
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
        }
    }
}