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
            SomeEnum bla = SomeEnum.More;

            switch(bla)
            {
                case SomeEnum.More:
                    System.Console.Write("More");
                    return;
                case SomeEnum.All:
                    System.Console.Write("All");
                    return;
                default:
                    System.Console.Write("Default");
                    return;
            }
        }
    }

    public enum SomeEnum
    {
        All,
        Many,
        More
    }
}