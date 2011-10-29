using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;
using Strokes.Core;

namespace Strokes.BasicAchievements.NRefactory
{
    public abstract class AbstractAchievementVisitor : DepthFirstAstVisitor<object, object>
    {
        public AchievementCodeOrigin CodeOrigin
        {
            get;
            set;
        }

        public virtual bool IsAchievementUnlocked
        {
            get;
            set;
        }

        protected override object VisitChildren(AstNode node, object data)
        {
            //This little trick should make nrefactory stop visiting as soon as an achievement is unlocked and save consideral performance in large files
            if (!IsAchievementUnlocked)
            {
                return base.VisitChildren(node, data);
            }

            return default(object);
        }

        protected virtual void UnlockWith(AstNode location)
        {
            CodeOrigin = new AchievementCodeOrigin();

            CodeOrigin.From.Line = location.StartLocation.Line;
            CodeOrigin.From.Column = location.StartLocation.Column;

            CodeOrigin.To.Line = location.EndLocation.Line;
            CodeOrigin.To.Column = location.EndLocation.Column;

            IsAchievementUnlocked = true;
        }

        public virtual void OnParsingCompleted()
        {
        }
    }
}
