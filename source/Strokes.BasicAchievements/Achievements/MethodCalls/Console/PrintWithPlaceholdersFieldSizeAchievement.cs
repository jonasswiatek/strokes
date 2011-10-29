using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;
using System.Text.RegularExpressions;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{043B1CD0-D052-4D1D-B605-554CAB6FC8DF}", "@PrintWithPlaceholdersFieldSizeAchievementName",
        AchievementDescription = "@PrintWithPlaceholdersFieldSizeAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/txafckwd(v=VS.110).aspx",
        AchievementCategory = "@Console")]
    public class PrintWithPlaceholdersFieldSizeAchievement : AbstractSystemTypeUsage
    {
        public PrintWithPlaceholdersFieldSizeAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            var firstParam = invocationExpression.Arguments.First() as PrimitiveExpression;
            if (firstParam != null)
            {
                const RegexOptions regexOpts = RegexOptions.IgnorePatternWhitespace;
                const string regex = @"\{ *\d *\, *\d\ *}";

                return Regex.IsMatch(firstParam.Value.ToString(), regex, regexOpts);
            }

            return false;
        }
    }
}