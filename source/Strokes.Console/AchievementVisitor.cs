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
        public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
        {
            if(typeDeclaration.Type == ClassType.Enum)
            {
                System.Console.WriteLine("Enum");
            }
            
            return base.VisitTypeDeclaration(typeDeclaration, data);
        }

        public override object VisitDoLoopStatement(DoLoopStatement doLoopStatement, object data)
        {
            if(doLoopStatement.ConditionPosition == ConditionPosition.End)
            {
                System.Console.WriteLine("Do-While");
            }
            else if (doLoopStatement.ConditionPosition == ConditionPosition.Start)
            {
                System.Console.WriteLine("While");
            }
            return base.VisitDoLoopStatement(doLoopStatement, data);
        }

        public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
        {
            if((fieldDeclaration.Modifier & Modifiers.Const) == Modifiers.Const)
            {
                System.Console.WriteLine("Constant field");
            }
            
            return base.VisitFieldDeclaration(fieldDeclaration, data);
        }

        public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
        {
            if((localVariableDeclaration.Modifier & Modifiers.Const) == Modifiers.Const)
            {
                System.Console.WriteLine("Constant local var");
            }
            return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
        }

        public override object VisitVariableDeclaration(VariableDeclaration variableDeclaration, object data)
        {
            var primExp = variableDeclaration.Initializer as PrimitiveExpression;
            System.Console.WriteLine(primExp);
            return base.VisitVariableDeclaration(variableDeclaration, data);
        }

        public override object VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data)
        {
            var bla = "";
            return base.VisitAnonymousMethodExpression(anonymousMethodExpression, data);
        }

        public override object VisitAssignmentExpression(AssignmentExpression assignmentExpression, object data)
        {
            var bla = "";
            return base.VisitAssignmentExpression(assignmentExpression, data);
        }
    }
}
