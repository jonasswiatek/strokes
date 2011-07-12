using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    public abstract class NRefactoryAchievement : Achievement
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();

            var unlocked = false;
            foreach(var file in detectionSession.BuildInformation.ChangedFiles)
            {
                var parser = nRefactorySession.GetParser(file);
                parser.Parse();

                var result = parser.CompilationUnit;
                var visitor = CreateVisitor();

                result.AcceptVisitor(visitor, null);

                if(visitor.IsAchievementUnlocked)
                {
                    AchievementCodeLocation = visitor.CodeLocation;
                    if(AchievementCodeLocation != null)
                    {
                        AchievementCodeLocation.FileName = file;
                    }
                    
                    unlocked = true;
                    break;
                }
            }

            return unlocked;
        }

        protected abstract AbstractAchievementVisitor CreateVisitor();

        protected abstract class AbstractAchievementVisitor : AbstractAstVisitor
        {
            public AchievementCodeLocation CodeLocation;

            public void UnlockWith(AbstractNode location)
            {
                CodeLocation = new AchievementCodeLocation();

                CodeLocation.From.Line = location.StartLocation.Line;
                CodeLocation.From.Column = location.StartLocation.Column;

                CodeLocation.To.Line = location.EndLocation.Line;
                CodeLocation.To.Column = location.EndLocation.Column;

                IsAchievementUnlocked = true;
            }

            /*public override object VisitCompilationUnit(CompilationUnit compilationUnit, object data)
            {
                return compilationUnit.AcceptChildren(this, data);
            }*/


            public bool IsAchievementUnlocked;
        }
    }
}
