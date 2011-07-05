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
            var parser = nRefactorySession.GetParser(detectionSession.BuildInformation.ActiveFile);
            parser.Parse();

            var result = parser.CompilationUnit;
            var visitor = CreateVisitor();

            result.AcceptVisitor(visitor, Guid.NewGuid());
            return visitor.IsAchievementUnlocked;
        }

        protected abstract AbstractAchievementVisitor CreateVisitor();

        protected abstract class AbstractAchievementVisitor : AbstractAstVisitor
        {
            public bool IsAchievementUnlocked;
        }
    }
}
