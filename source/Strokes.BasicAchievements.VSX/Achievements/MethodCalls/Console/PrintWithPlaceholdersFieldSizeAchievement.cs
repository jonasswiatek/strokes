using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Use placeholders and field size when writing to the screen", AchievementDescription = "Print something to the console using placeholders and explicit field sizes", AchievementCategory = "Console")]
    public class PrintWithPlaceholdersFieldSizeAchievement : AbstractMethodCall
    {
        public PrintWithPlaceholdersFieldSizeAchievement() : base("System.Console.WriteLine")
        {
            var requirementSet = new TypeAndValueRequirementSet
                                     {
                                         Repeating = true,
                                         Requirements = new List<TypeAndValueRequirement>
                                                            {
                                                                new TypeAndValueRequirement
                                                                    {
                                                                        Type = typeof (string),
                                                                        Regex = @"\{ *\d *\, *\d\ *}"  //Tim: Isn't there a way to simply let the regex ignore whitespace?  / ... /x doesn't work....
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