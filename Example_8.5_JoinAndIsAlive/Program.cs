using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_8._5_JoinAndIsAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main started");
            Thread t1 = new Thread(Thread1Func);
            t1.Start();

            Thread t2 = new Thread(Thread2Func);
            t2.Start();

            //TODO: Add params to Join and add IsAlive check
            t1.Join(2000);
            if (t1.IsAlive)
            {
                Console.WriteLine("Thread1Func is still working");
            }
            else
            {
                Console.WriteLine("Thread1Func complete");
            }

            t2.Join();
            Console.WriteLine("Thread2Func complete");

            Console.WriteLine("Main completed");
            Console.ReadLine();
        }

        public static void Thread1Func()
        {
            Console.WriteLine("Thread1Func started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Func is about to return");
        }

        public static void Thread2Func()
        {
            Console.WriteLine("Thread2Func started");
        }
    }
    
}
