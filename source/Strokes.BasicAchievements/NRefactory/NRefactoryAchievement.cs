using System;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    /// <summary>
    /// Base class for achievements that use a straight-forward NRefactory method to detect achievements
    /// </summary>
    public abstract class NRefactoryAchievement : AchievementBase
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            var nRefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();

            var unlocked = false;
         
            if (string.IsNullOrEmpty(detectionSession.BuildInformation.ActiveFile))
            {
                return false;
            }

            var visitor = CreateVisitor();

            var parser = nRefactorySession.GetParser(detectionSession.BuildInformation.ActiveFile);
            parser.Parse();
            parser.CompilationUnit.AcceptVisitor(visitor, null);

            //Call OnParsingCompleted on the visitor to allow it to do last-change achievement testing
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
            public AchievementCodeLocation CodeLocation;
            public bool IsAchievementUnlocked;

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
