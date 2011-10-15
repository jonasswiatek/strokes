using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{0ec683c7-8005-4da1-abf9-7d027ec1256f}", "@InheritClassAchievementName",
        AchievementDescription = "@InheritClassAchievementDescription",
        AchievementCategory = "@Class",
        DependsOn = new[]
                {
                    "{106AA91A-C351-41F7-9F19-1EC599320306}"
                })]
    public class InheritClassAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                //TODO: Also unlocks when only implementing an interface (so we will need a way to 
                // know if BaseType is a class or not. Now I simply detect of basetype doens't start with I
                if (typeDeclaration.Type == ClassType.Class && typeDeclaration.BaseTypes.Count > 0)
                {
                    foreach (var typeReference in typeDeclaration.BaseTypes)
                    {
                        if(!typeReference.Type.StartsWith("I"))
                        {
                            UnlockWith(typeDeclaration);
                            break;
                        }
                    }
                    UnlockWith(typeDeclaration);
                }
                

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}