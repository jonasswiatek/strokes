using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{295A339C-1ED6-41CF-951E-7E13632B01BD}", "@PrintWithPlaceholdersAchievementName",
        AchievementDescription = "@PrintWithPlaceholdersAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/txafckwd(v=VS.110).aspx",
        AchievementCategory = "@Console")]
    public class PrintWithPlaceholdersAchievement : AbstractSystemTypeUsage
    {
        public PrintWithPlaceholdersAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            var firstParam = invocationExpression.Arguments.First() as PrimitiveExpression;
            if (firstParam != null)
            {
                const RegexOptions regexOpts = RegexOptions.IgnorePatternWhitespace;
                const string regex = @"\{ *\d *\}";

                return Regex.IsMatch(firstParam.Value.ToString(), regex, regexOpts);
            }

            return false;
        }
    }
}