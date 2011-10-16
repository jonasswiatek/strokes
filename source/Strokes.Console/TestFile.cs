// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Threading;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    public class Test
    {
        public Test()
        {
            System.Console.WriteLine("Hello World!");

            G<A> g = new G<A>();
        }
    }

    public class A
    {
    }

    public class G<T>
    {
    }
}

#pragma warning restore