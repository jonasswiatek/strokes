using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements.MethodCalls
{
    [AchievementDescriptor("{614E5F45-BE9C-4202-8A19-568E5A7D9467}", "@PrintNewLineAchievementName",
        AchievementDescription = "@PrintNewLineAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/h21280bw.aspx",
        AchievementCategory = "@Console")]
    public class PrintNewLineAchievement : AbstractSystemTypeUsage
    {
        public PrintNewLineAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return invocationExpression.Arguments.OfType<PrimitiveExpression>().Any(a => a.LiteralValue.Contains(@"\n"));
        }
    }

    [AchievementDescriptor("{411ABF94-05A8-44F4-8219-D5B6D1E1F439}", "@PrintHorizontalTabAchievementName",
        AchievementDescription = "@PrintHorizontalTabAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/h21280bw.aspx",
        AchievementCategory = "@Console")]
    public class PrintHorizontalTabAchievement : AbstractSystemTypeUsage
    {
        public PrintHorizontalTabAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return invocationExpression.Arguments.OfType<PrimitiveExpression>().Any(a => a.LiteralValue.Contains(@"\t"));
        }
    }

    [AchievementDescriptor("{96E443E6-C6A3-4A04-95F5-F72A2FCCC07C}", "@PrintQuoteCharAchievementName",
        AchievementDescription = "@PrintQuoteCharAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/h21280bw.aspx",
        AchievementCategory = "@Console")]
    public class PrintQuoteCharAchievement : AbstractSystemTypeUsage
    {
        public PrintQuoteCharAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return invocationExpression.Arguments.OfType<PrimitiveExpression>().Any(a => a.Value.ToString().Contains("\""));
        }
    }

    [AchievementDescriptor("{48513581-C29E-4298-92B2-A20AD8BCC01C}", "@PrintSingleQuoteCharAchievementName",
        AchievementDescription = "@PrintSingleQuoteCharAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/h21280bw.aspx",
        AchievementCategory = "@Console")]
    public class PrintSingleQuoteCharAchievement : AbstractSystemTypeUsage
    {
        public PrintSingleQuoteCharAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return invocationExpression.Arguments.OfType<PrimitiveExpression>().Any(a => a.Value.ToString().Contains("\'"));
        }
    }

    [AchievementDescriptor("{815C33AD-41E9-43F8-B204-F9A157DD8AB6}", "@PrintBackSlashCharAchievementName",
        AchievementDescription = "@PrintBackSlashCharAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/h21280bw.aspx",
        AchievementCategory = "@Console")]
    public class PrintBackSlashCharAchievement : AbstractSystemTypeUsage
    {
        public PrintBackSlashCharAchievement() : base(typeof(System.Console), "WriteLine")
        {
        }

        protected override bool VerifyArgumentUsage(InvocationExpression invocationExpression)
        {
            return invocationExpression.Arguments.OfType<PrimitiveExpression>().Any(a => a.Value.ToString().Contains("\\"));
        }
    }
}