using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{bf48a1f8-30f4-4374-aa94-bdc56692f234}", "@CreateGenericObjectAchievementName",
        AchievementDescription = "@CreateGenericObjectAchievementDescription",
        AchievementCategory = "@Generics",
        DependsOn = new[]
                {
                    "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
                }
                )]
    public class CreateGenericObjectAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
            {
                if(objectCreateExpression.CreateType.GenericTypes.Count>0)
                {
                    UnlockWith(objectCreateExpression);
                }
                return base.VisitObjectCreateExpression(objectCreateExpression, data);
            }
        }
    }
}