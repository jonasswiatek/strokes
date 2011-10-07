using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("{7050FB47-A763-46EF-B241-8E9521E19B1A}", "@FormatSpecifierAchievementName",
        AchievementDescription = "@FormatSpecifierAchievementDescription",
        AchievementCategory = "@Console")]
    public class FormatSpecifierAchievement : AbstractMethodCall
    {
        public FormatSpecifierAchievement()
            : base("Console.WriteLine")
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
                        Regex = @"\{ *\d *\: *[C,c,D,d,E,e,F,f,G,g,N,n,X,x]\d*\}"  
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
