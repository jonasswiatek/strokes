using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@ProgramWithStartupParamsAchievementName",
        AchievementDescription = "@ProgramWithStartupParamsAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class ProgramWithStartupParamsAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.Parameters.Count==1)
                        {
                            ParameterDeclarationExpression param = methodDeclaration.Parameters[0];

                            if(param.ParameterName.Equals("args") && param.TypeReference.ToString().Equals("System.String[]"))
                            {
                                //now check if body uses argsparam
                                //This is waaaaay to naive....
                                if(methodDeclaration.Body.ToString().Contains("args"))
                                {
                                    UnlockWith(methodDeclaration);
                                }

                            }
                        }
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}