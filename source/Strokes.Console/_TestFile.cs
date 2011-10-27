// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test1pokemon2
{
    class Program
    {
        [STAThread]
        static void main(string[] args)
        {
            System.Console.WriteLine("Some value: {0:D}", 1);
        }
    }
}
#pragma warning restore
