using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;

namespace Strokes.BasicAchievements.NRefactory
{
    public static class NRefactoryTools
    {
        public static string GetCallChainAsString(this MemberReferenceExpression memberReferenceExpression)
        {
            var callChain = new List<string>()
            {
                memberReferenceExpression.MemberName
            };

            Expression reference = memberReferenceExpression.TargetObject;

            while (reference != null)
            {
                if (reference is MemberReferenceExpression)
                {
                    callChain.Add((reference as MemberReferenceExpression).MemberName);

                    reference = memberReferenceExpression.TargetObject as IdentifierExpression;
                }
                else if (reference is IdentifierExpression)
                {
                    var identifier = (reference as IdentifierExpression).Identifier;

                    // Ignore the 'System' namespace.
                    if (identifier != "System")
                        callChain.Add(identifier);

                    break;
                }
            }

            // Reverse the callstring, so 'Clear.Array.System' becomes 'System.Array.Clear'.
            callChain.Reverse();

            return string.Join(".", callChain);
        }
    }
}
