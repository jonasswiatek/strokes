using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescription("Format Specifier", AchievementDescription = "Print something to the console using a format specifier", AchievementCategory = "Console")]
    public class FormatSpecifierAchievement : AbstractMethodCall
    {
        public FormatSpecifierAchievement() : base("System.Console.WriteLine") 
        {
            var requirementSet = new TypeAndValueRequirementSet
            {
                Repeating = true,
                Requirements = new List<TypeAndValueRequirement>
                                                            {
                                                                new TypeAndValueRequirement
                                                                    {
                                                                        Type = typeof (string),
                                                                        Regex = @"\{ *\d *\: *[C,c,D,d,E,e,F,f,G,g,N,n,X,x]\d*\}"  //Tim: Isn't there a way to simply let the regex ignore whitespace?  / ... /x doesn't work....
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
