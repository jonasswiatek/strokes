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
        public enum FooBarBaz
        {
            Foo,
            Bar,
            Baz
        }

        public void Test()
        {
            foreach (FooBarBaz item in System.Enum.GetValues(typeof(FooBarBaz)))
            {
            }
        }
    }
}

#pragma warning restore
