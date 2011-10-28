using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{295A339C-1ED6-41CF-951E-7E13632B01BD}", "@PrintWithPlaceholdersAchievementName",
        AchievementDescription = "@PrintWithPlaceholdersAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/txafckwd(v=VS.110).aspx",
        AchievementCategory = "@Console")]
    public class PrintWithPlaceholdersAchievement : AbstractMethodCall
    {
        public PrintWithPlaceholdersAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        RegexOptions = RegexOptions.IgnorePatternWhitespace,
                        Regex = @"\{ *\d *\}"
                    },
                }
            });
        }
    }
}