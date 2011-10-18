// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Threading;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Testing
{
    public class TestFile : Bla
    {
        public TestFile() : base()
        {
            
        }
        public static void main(string[] args)
        {
            var bla = args[0];
        }
    }

    public class Bla
    {
        public Bla()
        {
            
        }
    }
}

#pragma warning restore
