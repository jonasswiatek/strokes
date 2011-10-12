// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Threading;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    public class GenericList<T>
    {
        void Add(T input) { }
    }
    public class TestFile : IComparable
    {
        public TestFile()
        {
            GenericList<int> list1 = new GenericList<int>();
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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

#pragma warning restore