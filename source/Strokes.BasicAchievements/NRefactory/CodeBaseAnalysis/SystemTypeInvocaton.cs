using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.CSharp;

namespace Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis
{
    public class SystemTypeInvocaton
    {
        public Type SystemType;
        public string MethodName;
        public InvocationExpression OriginalExpression;
        public List<InvocationExpression> Variations = new List<InvocationExpression>();
    }
}
