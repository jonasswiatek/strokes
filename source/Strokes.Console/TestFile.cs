// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    public class TestFile
    {
        public void Method()
        {
            int[] foo = new int[] { 1, 2, 3 };

            Array.Clear(foo, 0, 1);
        }
    }
}

#pragma warning restore