// Ignore warnings in the test file.
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace test1pokemon2
{
    class Program
    {
        [STAThread]
        static void main(string[] args)
        {
            Console.WriteLine("Some value: {0:D}", 1);
            var t = new Thread(() => { });
            t.Start();
        }
    }
}
#pragma warning restore
