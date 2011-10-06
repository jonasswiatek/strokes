using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("@IComparableAchievementName",
        AchievementDescription = "@IComparableAchievementDescription",
        AchievementCategory = "@Class")]
    public class IComparableAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.Type == ClassType.Class)
                {
                    foreach (var basetype in typeDeclaration.BaseTypes)
                    {
                        if (basetype.Type == "System.IComparable" || basetype.Type == "IComparable")
                        {
                            UnlockWith(typeDeclaration);
                            break;
                        }
                    }
                    
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}