using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Hello world", AchievementDescription = "Write the most-writen program ever", AchievementCategory = "Console")]
    public class HelloWorldAchievement : AbstractMethodCall
    {
        public HelloWorldAchievement(): base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
                                     {
                                         Repeating = true,
                                         Requirements = new List<TypeAndValueRequirement>
                                                            {
                                                                new TypeAndValueRequirement
                                                                    {
                                                                        Type = typeof (string),
                                                                        Regex = @"hello world"
                                                                    },
                                                                new TypeAndValueRequirement
                                                                    {
                                                                        Type = typeof (object)
                                                                    }
                                                            }
                                     };

            RequiredOverloads.Add(requirementSet);
        }
    }
}