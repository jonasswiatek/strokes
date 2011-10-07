using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Visitors;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescription("{2EF5C718-C944-40A0-AFDD-8142B6E15A42}", "@DeclareInitArrayAchievementName",
        AchievementDescription = "@DeclareInitArrayAchievementDescription",
        AchievementCategory = "@Arrays")]
    public class DeclareInitArrayAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                if (localVariableDeclaration.TypeReference.IsArrayType)
                {
                    if (localVariableDeclaration.Variables.Count > 0)
                    {

                        VariableDeclaration decl = localVariableDeclaration.Variables[0] as VariableDeclaration;
                        if (decl != null)
                        {
                            if(decl.Initializer is CollectionInitializerExpression)
                                UnlockWith(localVariableDeclaration);
                            else if (decl.Initializer is ArrayCreateExpression)
                            {
                                ArrayCreateExpression decl2 = decl.Initializer as ArrayCreateExpression;
                                if (decl2.ArrayInitializer is CollectionInitializerExpression && decl2.ArrayInitializer.CreateExpressions.Count>0)
                                {
                                    
                                    UnlockWith(decl2.ArrayInitializer);
                                }
                                  
                            }
                        }
                    }
                    
                }
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
        }
    }
}