using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    /// <summary>
    /// Base class for achievements that use a straight-forward NRefactory method to detect achievements
    /// </summary>
    public abstract class NRefactoryAchievement : AchievementBase
    {
        protected NRefactoryContext NRefactoryContext { get; private set; }

        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            // Return out if there are no files to check achievements in.
            if (!detectionSession.BuildInformation.ChangedFiles.Any())
            {
                return false;
            }

            // Obtain a session object and the codebase type declarations
            var nrefactorySession = detectionSession.GetSessionObjectOfType<NRefactorySession>();
            NRefactoryContext = new NRefactoryContext()
                                    {
                                        CodebaseDeclarations = nrefactorySession.GetCodebaseDeclarations(detectionSession.BuildInformation)
                                    };

            // Have the concrete implementation create it's visitor
            var visitor = CreateVisitor(detectionSession);

            // Parse all files in the changed files collection for achievements
            foreach (var filename in detectionSession.BuildInformation.ChangedFiles)
            {
                // Obtain a parser from the nrefactorySession. 
                // This parser is shared context between all concrete achievement implementations.
                var compilationUnit = nrefactorySession.GetCompilationUnit(filename);

                // Pass concrete visitor into the AST created by the parser
                compilationUnit.AcceptVisitor(visitor, null);

                // Call OnParsingCompleted on the visitor to give it a last chance to unlock achievements.
                visitor.OnParsingCompleted();

                // Check if the visitor declared the concrete achievement as unlocked.
                if (visitor.IsAchievementUnlocked)
                {
                    AchievementCodeLocation = visitor.CodeLocation;
                    if (AchievementCodeLocation != null)
                    {
                        AchievementCodeLocation.FileName = filename;
                    }

                    return true;
                }
            }

            return false;
        }

        protected abstract AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession);

        protected abstract class AbstractAchievementVisitor : DepthFirstAstVisitor<object, object> 
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

            protected void UnlockWith(AstNode location)
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
