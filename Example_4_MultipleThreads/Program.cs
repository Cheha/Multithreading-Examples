using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_4_MultipleThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(DifferentThread);
            thread.Start();
            while (true)
            {
                Console.WriteLine("Hello from Main " + 
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }

        static void DifferentThread()
        {
            //  Console.WriteLine("My name is Alex");
            while (true)
            {
                Console.WriteLine("Hello from DifferentMethod " + 
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);
            }
        }
    }
}
