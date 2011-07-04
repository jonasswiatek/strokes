using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("Declare and initialize int", AchievementDescription = "Declare and initialize int in one statement", AchievementCategory = "Basic Achievements")]
    public class IntDeclareAndInitializeAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
            {
                if (fieldDeclaration.TypeReference.Type == "System.Int32")
                {
                    if(fieldDeclaration.Fields.Count > 0)
                    {
                        if(fieldDeclaration.Fields[0].Initializer is PrimitiveExpression)
                        {
                            IsAchievementUnlocked = true;
                        }
                    }
                }

                return base.VisitFieldDeclaration(fieldDeclaration, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type == "System.Int32")
                {
                    if (localVariableDeclaration.Variables.Count > 0)
                    {
                        if (localVariableDeclaration.Variables[0].Initializer is PrimitiveExpression)
                        {
                            IsAchievementUnlocked = true;
                        }
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}
