using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using Strokes.Core;
using Strokes.BasicAchievements.NRefactory;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{5EA1926B-0EF7-4B7A-AAA3-729702F44F97}", "@DeclareEscapeCharAchievementName",
        AchievementDescription = "@DeclareEscapeCharAchievementDescription",
        AchievementCategory = "@PrimitiveType")]
    public class DeclareEscapeCharAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            

            public override object VisitLocalVariableDeclaration(ICSharpCode.NRefactory.Ast.LocalVariableDeclaration localVariableDeclaration, object data)
            {

                if (localVariableDeclaration.TypeReference.ToString().Equals("System.Char"))
                {
                    foreach (VariableDeclaration declaration in localVariableDeclaration.Variables)
                    {
                        if(declaration.Initializer is PrimitiveExpression)
                        {
                            PrimitiveExpression prim = (PrimitiveExpression)declaration.Initializer;

                            var regex = new Regex("\\\\.{1}");
                            if (regex.IsMatch(prim.StringValue))
                            {
                                UnlockWith(localVariableDeclaration);
                            }

                        }
                    }
                }
                
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }

        }
    }
}
