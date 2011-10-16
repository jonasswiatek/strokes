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
    [AchievementDescriptor("{ADEDE81C-9350-40AB-882F-30856B2C6E5C}", "@BlockCommentAchievementName",
        AchievementDescription = "@BlockCommentAchievementDescription",
        AchievementCategory = "@Fundamentals",
        Image = "/Strokes.BasicAchievements;component/Achievements/Icons/Basic/BlockComment.png")]

    public class BlockCommentAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitComment(Comment comment, object data)
            {
                if(comment.CommentType == CommentType.MultiLine)
                {
                    UnlockWith(comment);
                }

                return base.VisitComment(comment, data);
            }
        }
    }
}
