using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{463CA967-E431-4479-AE4C-2F318C00DD09}", "@DangerousEqualityCheckAchievementName",
        AchievementDescription = "@DangerousEqualityCheckAchievementDescription",
        AchievementCategory = "@ProgramFlow")]
    public class DangerousEqualityCheckAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            /* REFACTOR
            public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
            {
                bool leftdangerous = false;
                bool rightdangerous = false;
                if(binaryOperatorExpression.Operator == BinaryOperatorType.Equality)
                {
                    if(binaryOperatorExpression.Left is PrimitiveExpression)
                    {
                        PrimitiveExpression prim = (PrimitiveExpression) binaryOperatorExpression.Left;
                        if (prim.LiteralFormat == LiteralFormat.DecimalNumber)
                            leftdangerous = true;
                    }
                    
                     else if (binaryOperatorExpression.Left is IdentifierExpression)
                     {
                         IdentifierExpression idexpr = (IdentifierExpression) binaryOperatorExpression.Left;
                         if (_doublefloatvariables.Contains(idexpr.Identifier))
                         {
                             leftdangerous = true;
                         }
                     }


                    if (binaryOperatorExpression.Right is PrimitiveExpression)
                    {
                        PrimitiveExpression prim = (PrimitiveExpression)binaryOperatorExpression.Right;
                        if (prim.LiteralFormat == LiteralFormat.DecimalNumber)
                            rightdangerous = true;
                    }


                    else if (binaryOperatorExpression.Right is IdentifierExpression)
                    {
                        IdentifierExpression idexpr = (IdentifierExpression)binaryOperatorExpression.Right;
                        if (_doublefloatvariables.Contains(idexpr.Identifier))
                        {
                            rightdangerous = true;
                        }
                    }

                    if(leftdangerous || rightdangerous)
                    {
                        UnlockWith(binaryOperatorExpression);
                    }
                }
                return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
            }
            */

            private readonly List<string> _doublefloatvariables = new List<string>();

            /* //REFACTOR
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {

                if (localVariableDeclaration.TypeReference.Type.Contains("System.Double")
                    || localVariableDeclaration.TypeReference.Type.Contains("System.Float")
                    || localVariableDeclaration.TypeReference.Type.Contains("System.Decimal"))
                {
                    foreach (VariableDeclaration variableDeclaration in localVariableDeclaration.Variables)
                    {
                        _doublefloatvariables.Add(variableDeclaration.Name);
                    }
                }
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }*/

        }
    }
}