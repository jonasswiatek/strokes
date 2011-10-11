using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    // TODO: Implement achievements below.
    // Fun achievements from: http://blog.whiletrue.com/2011/01/what-if-visual-studio-had-achievements/
    //
    // Spaghetti Monster – Written a single line with more than 300 characters
    // Pasta Chef – Created a class with more than 100 fields, properties or methods
    // The Poet – Written a source file with more than 10,000 lines
    // The Explainer – Written a comment with more than 100 words 
    // Paula – Define a firstname field with value Brillant
    // The Numerologist: Name all your controls: control1, control2, control3, etc
    // The Compound Sentence – created a method name containing one or more of the words: for, and, nor, but, or, yet, so.
    // Overloaded – Create a method with more that 10 overloads
    // Magic-maker – 5 or more magic numbers in a method
    // "Over-qualified": "using System;" is your only using directive.
    // "Under-qualified": Write a using directive for every conceivable namespace used by your program.
    // "e.e. cummings": Write so many nested classes, functions, and control structures, that the first character of a line is on or after column 73. 

    [AchievementDescriptor("{92F021CA-9F71-4FCB-A698-36948B6E8527}", "@JobSecurityAchievementName",
        AchievementDescription = "@JobSecurityAchievementDescription",
        AchievementCategory = "@Funny")]
    public class JobSecurityAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitQueryExpression(QueryExpression queryExpression, object data)
            {
                if (queryExpression.EndLocation.Line - queryExpression.StartLocation.Line >= 10)
                    UnlockWith(queryExpression);
                return base.VisitQueryExpression(queryExpression, data);
            }
        }
    }

    [AchievementDescriptor("{BF1C5DD9-3C0E-466B-9640-1F30F68FE960}", "@TellingAStoryAchievementName",
        AchievementDescription = "@TellingAStoryAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
                {
                    "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
                })]
    public class TellingAStoryAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                // TODO: Filter whitespace.

                if (methodDeclaration.Body.EndLocation.Line - methodDeclaration.Body.StartLocation.Line >= 100)
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{B82A5527-2F5A-4781-93C5-D5D0FEE22A0A}", "@EpicTaleAchievementName",
        AchievementDescription = "@EpicTaleAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
                {
                    "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
                })]
    public class EpicTaleAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                // TODO: Filter whitespace.

                if (methodDeclaration.Body.EndLocation.Line - methodDeclaration.Body.StartLocation.Line >= 300)
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{A93A63A8-30DC-45A8-BCFE-DFADF6BDDF38}", "@ParametizerAchievementName",
        AchievementDescription = "@ParametizerAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
                {
                    "{14DEE0A5-8D80-461D-AE99-B09627B27CE6}"
                })]
    public class ParametizerAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            int count = 0;
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Parameters.Count > 10)
                {
                    foreach (var param in methodDeclaration.Parameters)
                    {
                        if (param.ParamModifier.HasFlag(ParameterModifiers.Optional))
                            count++;

                    }
                    if (count > 10)
                        UnlockWith(methodDeclaration);
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{3C053533-04EC-4D18-B1F1-36AC3F2F1A5F}", "@GUTAchievementName",
        AchievementDescription = "@GUTAchievementDescription",
        AchievementCategory = "@Funny")]
    public class GUTAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.Type == ClassType.Class)
                {
                    var count = typeDeclaration.BaseTypes.Count(i => i.Type.StartsWith("I"));
                    if (count >= 5)
                        UnlockWith(typeDeclaration);
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{1C241CE0-0CF4-4A51-B0EB-F0157848A3D3}", "@EveryOptionEnumAchievementName",
        AchievementDescription = "@EveryOptionEnumAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new []{ "{1B9C1201-E2A9-4FE6-A8A6-44ABE06517FD}"})]
    public class EveryOptionEnumAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {

            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.Type == ClassType.Enum)
                {
                    if (typeDeclaration.Children.Count > 10)
                    {
                        UnlockWith(typeDeclaration);
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{AB9E0BC9-7CC1-431D-BA91-4A2FCB50B43E}", "@ProceduralProgrammerAchievementName",
        AchievementDescription = "@ProceduralProgrammerAchievementDescription",
        AchievementCategory = "@Funny",
        DependsOn = new[]
                {
                    "{8A5F199C-B171-42D4-A12E-69BFB8A9F547}"
                })]
    public class ProceduralProgrammerAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            int count = 0;
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (methodDeclaration.Parameters.Count > 9)
                {
                    foreach (var param in methodDeclaration.Parameters)
                    {
                        if (param.ParamModifier.HasFlag(ParameterModifiers.Out))
                            count++;

                    }
                    if (count > 9)
                        UnlockWith(methodDeclaration);
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }
}