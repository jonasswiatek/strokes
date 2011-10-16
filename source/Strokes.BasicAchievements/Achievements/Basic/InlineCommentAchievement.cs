using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{B3049AD8-51B0-40D9-A01F-DA7DDBF868BF}", "@InlineCommentAchievementName",
        AchievementDescription = "@InlineCommentAchievementDescription",
        AchievementCategory = "@Fundamentals")]

    public class InlineCommentAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitComment(Comment comment, object data)
            {
                if (comment.CommentType == CommentType.SingleLine)
                {
                    UnlockWith(comment);
                }

                return base.VisitComment(comment, data);
            }
        }
    }
}
