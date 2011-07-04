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

            var reference = memberReferenceExpression.TargetObject as MemberReferenceExpression;
            while (reference != null)
            {
                callChain.Add(reference.MemberName);
                if (reference.TargetObject is IdentifierExpression)
                {
                    var identifier = reference.TargetObject as IdentifierExpression;
                    callChain.Add(identifier.Identifier);
                    break;
                }

                reference = reference.TargetObject as MemberReferenceExpression;
            }

            return string.Join(".", callChain.ToArray().Reverse());
        }
    }
}
