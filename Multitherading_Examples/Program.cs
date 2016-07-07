using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrainAcademy.ThreadClass
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstThread();
            Console.ReadLine();
        }

        public static void OnlyThreadMeth() {
            for (int i = 0; i <= 10; i++) {
                Console.WriteLine("Counter: {0}, Thread: {1}", i, 
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }

        public static void FirstThread()
        {
            ThreadStart starter = new ThreadStart(OnlyThreadMeth);
            Thread thread1 = new Thread(starter);
            Thread thread2 = new Thread(starter);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}
