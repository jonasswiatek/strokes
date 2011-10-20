using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    public abstract class DeclarePrimitiveType<T> : NRefactoryAchievement
        where T : struct
    {
        protected override AbstractAchievementVisitor CreateVisitor(StatisAnalysisSession statisAnalysisSession)
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
            {
                if (fieldDeclaration.ReturnType.Is<T>() && fieldDeclaration.Variables.Any(a => a.Initializer.IsNull))
                {
                    UnlockWith(fieldDeclaration);
                }

                return base.VisitFieldDeclaration(fieldDeclaration, data);
            }

            public override object VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement, object data)
            {
                if (variableDeclarationStatement.Type.Is<T>() && variableDeclarationStatement.Variables.Any(a => a.Initializer.IsNull))
                {
                    UnlockWith(variableDeclarationStatement);
                }

                return base.VisitVariableDeclarationStatement(variableDeclarationStatement, data);
            }
        }
    }
}
