using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.Ast;

namespace Strokes.BasicAchievements.NRefactory
{
    public class NRefactoryTools
    {
        public static string GetCallChainAsString(MemberReferenceExpression memberReferenceExpression)
        {
            var callChain = new List<string>();

            callChain.Add(memberReferenceExpression.MemberName);

            Expression reference = memberReferenceExpression.TargetObject as IdentifierExpression;
            while (reference != null)
            {
                if (reference is MemberReferenceExpression)
                {
                    callChain.Add((reference as MemberReferenceExpression).MemberName);

                    reference = memberReferenceExpression.TargetObject as IdentifierExpression;
                }
                else if (reference is IdentifierExpression)
                {
                    callChain.Add((reference as IdentifierExpression).Identifier);
                    break;
                }
            }

            var callstring = string.Join(".", callChain.ToArray().Reverse());

            return callstring;
        }
    }
}
