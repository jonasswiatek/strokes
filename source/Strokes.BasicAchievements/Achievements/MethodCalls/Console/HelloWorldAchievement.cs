using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{4EEB0846-9F8C-486A-A712-F1D93B02E9E7}", "@HelloWorldAchievementName",
        AchievementDescription = "@HelloWorldAchievementDescription",
        AchievementCategory = "@Console")]
    public class HelloWorldAchievement : AbstractMethodCall
    {
        public HelloWorldAchievement() : base("System.Console.WriteLine")
        {
            RequiredOverloads.Add(new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                {
                    new TypeAndValueRequirement
                    {
                        Type = typeof (string),
                        Regex = @"hello world",
                        RegexOptions = RegexOptions.IgnoreCase
                    },
                }
            });
        }
    }
}