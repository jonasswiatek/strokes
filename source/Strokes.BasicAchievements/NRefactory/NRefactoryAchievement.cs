using System;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.Core;
using ICSharpCode.NRefactory;

namespace Strokes.BasicAchievements.NRefactory
{
    /// <summary>
    /// Base class for achievements that use a straight-forward NRefactory method to detect achievements
    /// </summary>
    public abstract class NRefactoryAchievement : AchievementBase
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var unlocked = false;
         
            if (string.IsNullOrEmpty(detectionSession.BuildInformation.ActiveFile))
            {
                return false;
            }

            var visitor = CreateVisitor();

            detectionSession.Parser.CompilationUnit.AcceptVisitor(visitor, null);

            visitor.OnParsingCompleted();

            if (visitor.IsAchievementUnlocked)
            {
                AchievementCodeLocation = visitor.CodeLocation;
                if (AchievementCodeLocation != null)
                {
                    AchievementCodeLocation.FileName = detectionSession.BuildInformation.ActiveFile;
                }

                unlocked = true;
            }

            return unlocked;
        }

        protected abstract AbstractAchievementVisitor CreateVisitor();

        protected abstract class AbstractAchievementVisitor : AbstractAstVisitor
        {
            public AchievementCodeLocation CodeLocation
            {
                get;
                set;
            }

            public bool IsAchievementUnlocked
            {
                get;
                set;
            }

            protected void UnlockWith(AbstractNode location)
            {
                CodeLocation = new AchievementCodeLocation();

                CodeLocation.From.Line = location.StartLocation.Line;
                CodeLocation.From.Column = location.StartLocation.Column;

                CodeLocation.To.Line = location.EndLocation.Line;
                CodeLocation.To.Column = location.EndLocation.Column;

                IsAchievementUnlocked = true;
            }

            public virtual void OnParsingCompleted()
            {
            }
        }
    }
}
