using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Ast;
using Strokes.BasicAchievements.NRefactory;
using Strokes.Core;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{79B84B4F-AF59-427F-9254-CC86C70D23D7}", "@EnumInitializerExplicitAchievementName",
        AchievementDescription = "@EnumInitializerExplicitAchievementDescription",
        AchievementCategory = "@Fundamentals")]
    public class EnumInitializerExplicitAchievement : NRefactoryAchievement
    {
        protected override AbstractAchievementVisitor CreateVisitor()
        {
            return new Visitor();
        }

        private class Visitor : AbstractAchievementVisitor
        {
            public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
            {
                if (typeDeclaration.Type == ClassType.Enum)
                {
                    foreach (var child in typeDeclaration.Children)
                    {
                        FieldDeclaration variablef = child as FieldDeclaration;
                        foreach (var field in variablef.Fields)
                        {
                            if (!field.Initializer.IsNull)
                                UnlockWith(typeDeclaration);
                        }
                    }
                }

                return base.VisitTypeDeclaration(typeDeclaration, data);
            }
        }
    }
}