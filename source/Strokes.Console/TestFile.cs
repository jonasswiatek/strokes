// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Threading;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    public class TestFile : IEquatable<int>, IEquatable<double>, IEquatable<byte>, IEquatable<decimal>, IEquatable<string>
    {
        public TestFile()
        {
        }

        #region IEquatable<int> Members

        public bool Equals(int other)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEquatable<double> Members

        public bool Equals(double other)
        {
            return false;
        }

        #endregion

        #region IEquatable<byte> Members

        public bool Equals(byte other)
        {
            return false;
        }

        #endregion

        #region IEquatable<decimal> Members

        public bool Equals(decimal other)
        {
            return false;
        }

        #endregion

        #region IEquatable<string> Members

        public bool Equals(string other)
        {
            return false;
        }

        #endregion
    }
}

#pragma warning restore