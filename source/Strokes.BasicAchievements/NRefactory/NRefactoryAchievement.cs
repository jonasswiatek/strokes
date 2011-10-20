using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.NRefactory
{
    /// <summary>
    /// Base class for achievements that use a straight-forward NRefactory method to detect achievements
    /// </summary>
    public abstract class NRefactoryAchievement : StaticAnalysisAchievementBase
    {
        protected NRefactoryContext NRefactoryContext { get; private set; }

        public override bool IsAchievementUnlocked(StatisAnalysisSession statisAnalysisSession)
        {
            // Return out if there are no files to check achievements in.
            if (!statisAnalysisSession.StaticAnalysisManifest.ChangedFiles.Any())
            {
                return false;
            }

            // Obtain a session object and the codebase type declarations
            var nrefactorySession = statisAnalysisSession.GetSessionObjectOfType<NRefactorySession>();
            NRefactoryContext = new NRefactoryContext()
                                    {
                                        CodebaseDeclarations = nrefactorySession.GetCodebaseDeclarations(statisAnalysisSession.StaticAnalysisManifest)
                                    };

            // Have the concrete implementation create it's visitor
            var visitor = CreateVisitor(statisAnalysisSession);

            // Parse all files in the changed files collection for achievements
            foreach (var filename in statisAnalysisSession.StaticAnalysisManifest.ChangedFiles)
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
                    AchievementCodeOrigin = visitor.CodeOrigin;
                    if (AchievementCodeOrigin != null)
                    {
                        AchievementCodeOrigin.FileName = filename;
                    }

                    return true;
                }
            }

            return false;
        }

        protected abstract AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession);

        protected abstract class AbstractAchievementVisitor : DepthFirstAstVisitor<object, object> 
        {
            public AchievementCodeOrigin CodeOrigin
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
                CodeOrigin = new AchievementCodeOrigin();

                CodeOrigin.From.Line = location.StartLocation.Line;
                CodeOrigin.From.Column = location.StartLocation.Column;

                CodeOrigin.To.Line = location.EndLocation.Line;
                CodeOrigin.To.Column = location.EndLocation.Column;

                IsAchievementUnlocked = true;
            }

            public virtual void OnParsingCompleted()
            {
            }
        }
    }
}
