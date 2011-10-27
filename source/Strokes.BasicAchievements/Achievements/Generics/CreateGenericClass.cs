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
    [AchievementDescriptor("{e5170595-efe0-41ab-a0cb-d3b6b0e74e83}", "@CreateGenericClassAchievementName",
        AchievementDescription = "@CreateGenericClassAchievementDescription",
        AchievementCategory = "@Generics",
        HintUrl = "http://msdn.microsoft.com/en-us/library/sz6zd40f(v=VS.100).aspx",
        DependsOn = new[]
        {
            "{0ec683c7-8005-4da1-abf9-7d027ec1256f}"
        })]
    public class CreateGenericClassAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                // Info for future achievements on this: 
                //     http://www.codeproject.com/Articles/72467/C-4-0-Covariance-And-Contravariance-In-Generics
                if (typeDeclaration.ClassType == ClassType.Class && typeDeclaration.Name != "Program")
                {
                    if (typeDeclaration.TypeParameters.Count > 0)
                    {
                        UnlockWith(typeDeclaration);
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}