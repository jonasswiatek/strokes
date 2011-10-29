using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{7050FB47-A763-46EF-B241-8E9521E19B1A}", "@FormatSpecifierAchievementName",
        AchievementDescription = "@FormatSpecifierAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/s8s7t687(v=vs.71).aspx",
        AchievementCategory = "@Console")]
    public class FormatSpecifierAchievement : AbstractSystemTypeUsage
    {
        public FormatSpecifierAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            if (invocationExpression.Arguments.Count >= 2 && invocationExpression.Arguments.First() is PrimitiveExpression)
            {
                var firstParam = invocationExpression.Arguments.First() as PrimitiveExpression;

                const RegexOptions regexOpts = RegexOptions.IgnorePatternWhitespace;
                const string regex = @"\{ *\d *\: *[C,c,D,d,E,e,F,f,G,g,N,n,X,x]\d*\}";

                return Regex.IsMatch(firstParam.Value.ToString(), regex, regexOpts);
            }

            return false;
        }
    }
}
