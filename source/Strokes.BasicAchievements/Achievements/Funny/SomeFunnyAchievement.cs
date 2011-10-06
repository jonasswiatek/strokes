using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    /* Fun achievements from: http://blog.whiletrue.com/2011/01/what-if-visual-studio-had-achievements/
    TO Do:
     * 
     
     * Spaghetti Monster – Written a single line with more than 300 characters
     * Pasta Chef – Created a class with more than 100 fields, properties or methods
     * The Poet – Written a source file with more than 10,000 lines
     * The Explainer – Written a comment with more than 100 words 
     * Paula – Define a firstname field with value Brillant
     * The Numerologist: Name all your controls: control1, control2, control3, etc
     * The Compound Sentence – created a method name containing one or more of the words: for, and, nor, but, or, yet, so.
     * Overloaded – Create a method with more that 10 overloads
     * Magic-maker – 5 or more magic numbers in a method
     * "Over-qualified": "using System;" is your only using directive.
     * "Under-qualified": Write a using directive for every conceivable namespace used by your program.
     * e.e. cummings":  Write so many nested classes, functions, and control structures, that the first character of a line is on or after column 73. 
     * 
     * */

    [AchievementDescription("@JobSecurityAchievementName",
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

    [AchievementDescription("@TellingAStoryAchievementName",
        AchievementDescription = "@TellingAStoryAchievementDescription",
        AchievementCategory = "@Funny")]
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
                if (methodDeclaration.Body.EndLocation.Line - methodDeclaration.Body.StartLocation.Line >= 100)
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescription("@EpicTaleAchievementName",
        AchievementDescription = "@EpicTaleAchievementDescription",
        AchievementCategory = "@Funny")]
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
                if (methodDeclaration.Body.EndLocation.Line - methodDeclaration.Body.StartLocation.Line >= 300)
                    UnlockWith(methodDeclaration);

                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescription("@ParametizerAchievementName",
        AchievementDescription = "@ParametizerAchievementDescription",
        AchievementCategory = "@Funny")]
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

    [AchievementDescription("@GUTAchievementName",
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
                int count = 0;
                if (typeDeclaration.Type == ClassType.Class)
                {
                    foreach (var basetype in typeDeclaration.BaseTypes)
                    {
                        if (basetype.Type.StartsWith("I")) //Tim: isn't there a way to infer if the basetypes are interfaces (like 3 lines above )?
                            count++;
                    }
                    if (count >= 5)
                        UnlockWith(typeDeclaration);

                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }

    [AchievementDescription("@EveryOptionEnumAchievementName",
        AchievementDescription = "@EveryOptionEnumAchievementDescription",
        AchievementCategory = "@Funny")]
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
                    if(typeDeclaration.Children.Count>10)
                    {
                        UnlockWith(typeDeclaration);
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }

    [AchievementDescription("@ProceduralProgrammerAchievementName",
        AchievementDescription = "@ProceduralProgrammerAchievementDescription",
        AchievementCategory = "@Funny")]
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