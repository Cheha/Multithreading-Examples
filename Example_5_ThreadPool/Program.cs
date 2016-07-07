using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_5_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(PrintJohn);
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintAlex), "Alex");
            ThreadPool.QueueUserWorkItem(callback , 4);
            
            Console.ReadLine();
        }

        static void PrintAlex(object state) {
            Console.WriteLine("Alex " + (string)state);
        }

        static void PrintJohn(object state) {
            Console.WriteLine("John " + (Int32)state);
        }
    }
}
