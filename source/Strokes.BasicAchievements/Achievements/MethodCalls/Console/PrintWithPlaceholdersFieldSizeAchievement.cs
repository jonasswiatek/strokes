using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{043B1CD0-D052-4D1D-B605-554CAB6FC8DF}", "@PrintWithPlaceholdersFieldSizeAchievementName",
        AchievementDescription = "@PrintWithPlaceholdersFieldSizeAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/txafckwd(v=VS.110).aspx",
        AchievementCategory = "@Console")]
    public class PrintWithPlaceholdersFieldSizeAchievement : AbstractMethodCall
    {
        public PrintWithPlaceholdersFieldSizeAchievement() : base("System.Console.WriteLine")
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
                        Regex = @"\{ *\d *\, *\d\ *}",  
                    },
                }
            });
        }
    }
}