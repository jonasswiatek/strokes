using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{614E5F45-BE9C-4202-8A19-568E5A7D9467}", "@PrintNewLineAchievementName",
        AchievementDescription = "@PrintNewLineAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintNewLineAchievement : AbstractMethodCall
    {
        public PrintNewLineAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
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
            });
        }
    }

    [AchievementDescriptor("{411ABF94-05A8-44F4-8219-D5B6D1E1F439}", "@PrintHorizontalTabAchievementName",
        AchievementDescription = "@PrintHorizontalTabAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintHorizontalTabAchievement : AbstractMethodCall
    {
        public PrintHorizontalTabAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
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
            });
        }
    }

    [AchievementDescriptor("{96E443E6-C6A3-4A04-95F5-F72A2FCCC07C}", "@PrintQuoteCharAchievementName",
        AchievementDescription = "@PrintQuoteCharAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintQuoteCharAchievement : AbstractMethodCall
    {
        public PrintQuoteCharAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
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
            });
        }
    }

    [AchievementDescriptor("{48513581-C29E-4298-92B2-A20AD8BCC01C}", "@PrintSingleQuoteCharAchievementName",
        AchievementDescription = "@PrintSingleQuoteCharAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintSingleQuoteCharAchievement : AbstractMethodCall
    {
        public PrintSingleQuoteCharAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
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
            });
        }
    }

    [AchievementDescriptor("{815C33AD-41E9-43F8-B204-F9A157DD8AB6}", "@PrintBackSlashCharAchievementName",
        AchievementDescription = "@PrintBackSlashCharAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintBackSlashCharAchievement : AbstractMethodCall
    {
        public PrintBackSlashCharAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
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
            });
        }
    }
}