﻿// Ignore warnings in the test file.
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
            if ("foo" == "bar" || "bar" == "foo")
            {
            }
        }
    }
}

#pragma warning restore