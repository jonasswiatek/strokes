using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class DeclarePrimitiveType<T> : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor(DetectionSession detectionSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            private string TypeToFind = typeof (T).ToString();
            public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
            {
                if (fieldDeclaration.TypeReference.Type == TypeToFind)
                {
                    if(fieldDeclaration.Fields.Count == 1)
                    {
                        if(fieldDeclaration.Fields[0].Initializer.IsNull)
                        {
                            UnlockWith(fieldDeclaration);
                        }
                    }
                }

                return base.VisitFieldDeclaration(fieldDeclaration, data);
            }

            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.Type == TypeToFind)
                {
                    if (localVariableDeclaration.Variables.Count == 1)
                    {
                        if (localVariableDeclaration.Variables[0].Initializer.IsNull)
                        {
                            UnlockWith(localVariableDeclaration);
                        }
                    }
                }

                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}
