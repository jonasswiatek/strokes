using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{DC239C85-97E5-45FB-8F87-B95E667C0F4F}", "@InstantiateObjectWithInitAchievementName",
        AchievementDescription = "@InstantiateObjectWithInitAchievementDescription",
        AchievementCategory = "@Class")]
    public class InstantiateObjectWithInitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression, object data)
            {
                if(objectCreateExpression.Initializer.Elements.Count > 0)
                {
                    UnlockWith(objectCreateExpression.Initializer);
                }

                return base.VisitObjectCreateExpression(objectCreateExpression, data);
            }
        }
    }
}