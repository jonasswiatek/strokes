using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{59AD4199-D634-485A-8007-18B3317EFF83}", "@AnonymousObjectAchievementName",
        AchievementDescription = "@AnonymousObjectAchievementDescription",
        AchievementCategory = "@Class",
        HintUrl = "http://msdn.microsoft.com/en-us/library/bb397696.aspx",
        Image = "/Strokes.BasicAchievements;component/Achievements/Icons/Basic/AnonObject.png")]
    public class AnonymousObjectAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                var anonInitializer = variableDeclarationStatement.Variables.FirstOrDefault(a => a.Initializer is AnonymousTypeCreateExpression);
                if (anonInitializer != null)
                {
                    UnlockWith(anonInitializer.Initializer);
                }

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}