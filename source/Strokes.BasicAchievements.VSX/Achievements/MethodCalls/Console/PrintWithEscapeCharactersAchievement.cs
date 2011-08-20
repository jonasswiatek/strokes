using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Print a newline using \\n", AchievementDescription = "Print a newline to the console using \\n", AchievementCategory = "Console")]
    public class PrintNewLineAchievement : AbstractMethodCall
    {
        public PrintNewLineAchievement() : base("System.Console.WriteLine")
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

            RequiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("Print a tab using \\t", AchievementDescription = "Print a horizontal tab to the console using \\t", AchievementCategory = "Console")]
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

            RequiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("Print a \" using \\\"", AchievementDescription = "Print a quote (\") to the console using \\\"", AchievementCategory = "Console")]
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

            RequiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("Print a \' using \\\'", AchievementDescription = "Print a quote (\') to the console using \\\'", AchievementCategory = "Console")]
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

            RequiredOverloads.Add(requirementSet);
        }
    }

    [AchievementDescription("Print a \\ using \\\\", AchievementDescription = "Print a quote (\\) to the console using \\\\", AchievementCategory = "Console")]
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

            RequiredOverloads.Add(requirementSet);
        }
    }

}