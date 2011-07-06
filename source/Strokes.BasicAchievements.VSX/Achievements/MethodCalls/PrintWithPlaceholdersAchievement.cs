using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Print with placeholders", AchievementDescription = "Print something to the console using placeholders", AchievementCategory = "Basic Achievements")]
    public class PrintWithPlaceholdersAchievement : AbstractMethodCall
    {
        public PrintWithPlaceholdersAchievement() : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
                                     {
                                         Repeating = true,
                                         Requirements = new List<TypeAndValueRequirement>
                                                            {
                                                                new TypeAndValueRequirement
                                                                    {
                                                                        Type = typeof (string),
                                                                        Regex = @"\{\d\}"
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