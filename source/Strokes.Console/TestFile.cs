using System;
using System.Windows;
using Strokes.Core;
using System.Linq;

namespace Strokes.Console
{
    public class TestFile
    {
         public TestFile()
         { }
         
         void go()
         {
          
         }
         void go(int y)
         {
         }public int MyProperty { get; set; }
    }

    public class pr
    {
        public void main()
        {
            TestFile t = new TestFile() { MyProperty = 43 };
        }
    }

}