using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("@PrintWithPlaceholdersFieldSizeAchievementName",
        AchievementDescription = "@PrintWithPlaceholdersFieldSizeAchievementDescription",
        AchievementCategory = "@Console")]
    public class PrintWithPlaceholdersFieldSizeAchievement : AbstractMethodCall
    {
        public PrintWithPlaceholdersFieldSizeAchievement() : base("Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        RegexOptions = RegexOptions.IgnorePatternWhitespace,
                        Regex = @"\{ *\d *\, *\d\ *}",  
                    },
                    new TypeAndValueRequirement
                    {
                        Type = typeof (object)
                    }
                }
            };

            requiredOverloads.Add(requirementSet);
        }
    }
}