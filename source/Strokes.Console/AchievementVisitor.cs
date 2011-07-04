using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using Attribute = ICSharpCode.NRefactory.Ast.Attribute;

namespace Strokes.Console
{
    public class AchievementVisitor : ICSharpCode.NRefactory.Visitors.AbstractAstVisitor 
    {
        public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
        {
            var primitiveExpression = assignmentExpression.Right as PrimitiveExpression;
            if (primitiveExpression != null)
            {

            }
            return base.VisitAssignmentExpression(assignmentExpression, data);
        }
    }
}
