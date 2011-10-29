using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{4EEB0846-9F8C-486A-A712-F1D93B02E9E7}", "@HelloWorldAchievementName",
        AchievementDescription = "@HelloWorldAchievementDescription",
        HintUrl = "http://en.wikipedia.org/wiki/Hello_world_program",
        AchievementCategory = "@Console")]
    public class HelloWorldAchievement : AbstractSystemTypeUsage
    {
        public HelloWorldAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            var firstParam = invocationExpression.Arguments.First() as PrimitiveExpression;
            if(firstParam != null)
            {
                return firstParam.Value.ToString().ToLower() == "hello world";
            }

            return false;
        }
    }
}