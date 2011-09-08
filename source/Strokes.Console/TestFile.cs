using System;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{

    public class Bl
    {
       public virtual void it(){}
    }

    public class TestFile:Bl
    {

        public void t(out int k, out int f, out int h)
        {
            var i = 4;
            k = 3;
            f = 6;
            h = 3;
        }

        public override sealed extern void it();

    }
}