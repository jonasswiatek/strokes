using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@PrintNewLineAchievementName",
        AchievementDescription = "@PrintNewLineAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintNewLineAchievement : AbstractMethodCall
    {
        public PrintNewLineAchievement()
            : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = @"\n"
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("@PrintHorizontalTabAchievementName",
        AchievementDescription = "@PrintHorizontalTabAchievementDescription",
        AchievementCategory = "Console")]
    public class PrintHorizontalTabAchievement : AbstractMethodCall
    {
        public PrintHorizontalTabAchievement()
            : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = @"\t"
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("@PrintQuoteCharAchievementName",
        AchievementDescription = "@PrintQuoteCharAchievementDescription",
        AchievementCategory = "Console")]
    public class PrintQuoteCharAchievement : AbstractMethodCall
    {
        public PrintQuoteCharAchievement()
            : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = "\\\""
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("@PrintSingleQuoteCharAchievementName",
        AchievementDescription = "@PrintSingleQuoteCharAchievementDescription",
        AchievementCategory = "Console")]
    public class PrintSingleQuoteCharAchievement : AbstractMethodCall
    {
        public PrintSingleQuoteCharAchievement()
            : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = "\\\'"
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("@PrintBackSlashCharAchievementName",
        AchievementDescription = "@PrintBackSlashCharAchievementDescription",
        AchievementCategory = "Console")]
    public class PrintBackSlashCharAchievement : AbstractMethodCall
    {
        public PrintBackSlashCharAchievement()
            : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = "\\\\"
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }

}