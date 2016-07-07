using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_3_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(DifferentThread);
            thread.Start();
        }

        static void DifferentThread() {
            Console.WriteLine("My name is Alex");
        }
    }
}
