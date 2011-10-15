using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{1E11C34E-516D-4E5B-A54C-75D4C2EC5E8A}", "@CreateMethodReturnVoidAchievementName",
        AchievementDescription = "@CreateMethodReturnVoidAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnVoidAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Void"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{317E2D95-478E-4058-AD56-998918FA78DC}", "@CreateMethodReturnIntAchievementName",
        AchievementDescription = "@CreateMethodReturnIntAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnIntAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Int32"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{91E2259F-39C0-4113-922C-2E396F9C8738}", "@CreateMethodReturnStringAchievementName",
        AchievementDescription = "@CreateMethodReturnStringAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnStringAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.String"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{7F3CEBE4-44BC-4E8C-A855-EEF8A55AF197}", "@CreateMethodReturnBoolAchievementName",
        AchievementDescription = "@CreateMethodReturnBoolAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnBoolAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Boolean"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{A71102EA-B29B-460C-AADA-485EFB6489D8}", "@CreateMethodReturnCharAchievementName",
        AchievementDescription = "@CreateMethodReturnCharAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnCharAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Char"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }


    [AchievementDescriptor("{D264A403-73CC-4902-89A8-651AD0C518DE}", "@CreateMethodReturnDoubleAchievementName",
        AchievementDescription = "@CreateMethodReturnDoubleAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnDoubleAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Double"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

    [AchievementDescriptor("{F9A53178-E4A0-448B-9664-817278B89A2F}", "@CreateMethodReturnFloatAchievementName",
        AchievementDescription = "@CreateMethodReturnFloatAchievementDescription",
        AchievementCategory = "@Method")]
    public class CreateMethodReturnFloatAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
            {
                if (!methodDeclaration.Name.ToLower().Equals("main") && !methodDeclaration.Modifier.HasFlag(Modifiers.Constructors))
                {
                    if (!methodDeclaration.IsExtensionMethod && !methodDeclaration.Modifier.HasFlag(Modifiers.Abstract))
                    {
                        if (methodDeclaration.TypeReference.ToString().Equals("System.Single"))
                            UnlockWith(methodDeclaration);
                    }
                }
                return base.VisitMethodDeclaration(methodDeclaration, data);
            }
        }
    }

}