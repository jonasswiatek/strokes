using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0F7D9D7E-8FEE-4981-842A-4F25E2F4E2CE}", "@CreateSingleLineMethodAchievementName",
        AchievementDescription = "@CreateSingleLineMethodAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateSingleLineMethodAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Name.ToLower().Equals("main") == false)
                {
                    if (methodDeclaration.IsExtensionMethod == false &&
                        methodDeclaration.HasModifier(Modifiers.Abstract) == false)
                    {
                        if (methodDeclaration.Body.Children.Count() == 1 &&
                            methodDeclaration.Body.Children.First() is ReturnStatement)
                        {
                            UnlockWith(methodDeclaration);
                        }
                    }
                }

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}