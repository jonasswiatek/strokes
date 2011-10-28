using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{7050FB47-A763-46EF-B241-8E9521E19B1A}", "@FormatSpecifierAchievementName",
        AchievementDescription = "@FormatSpecifierAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/s8s7t687(v=vs.71).aspx",
        AchievementCategory = "@Console")]
    public class FormatSpecifierAchievement : AbstractMethodCall
    {
        public FormatSpecifierAchievement() : base("System.Console.WriteLine")
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
                        Regex = @"\{ *\d *\: *[C,c,D,d,E,e,F,f,G,g,N,n,X,x]\d*\}"  
                    },
                    new TypeAndValueRequirement
                    {
                        Type = typeof (object)
                    }
                }
            });
        }
    }
}
