// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Threading;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Testing
{
    public class TestFile
    {
        public static void main(string[] argssss)
        {
            throw new Exception("very long exception message, oh yeah, hey there!");
        }
    }
}

#pragma warning restore
