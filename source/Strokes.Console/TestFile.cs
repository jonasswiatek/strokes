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
        public delegate void ChangedEventHandler(object sender, EventArgs e);
        public event ChangedEventHandler Changed;

        public TestFile()
        {
            this.Changed += new ChangedEventHandler(TestFile_Changed);

            Changed(this, EventArgs.Empty);
        }

        void TestFile_Changed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

#pragma warning restore