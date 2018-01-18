using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_0_Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Number.PrintNumbers);
            ThreadStart threadDelegate = Number.PrintNumbers;
            //Thread t1 = new Thread(threadDelegate);
            // Thread t1 = new Thread(delegate () {Number.PrintNumbers();});
            // Thread t1 = new Thread(() => Number.PrintNumbers());
            t1.Start();
        }
    }

    class Number
    {
        public static void PrintNumbers()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
    }
}
