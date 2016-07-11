using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_18_TaskFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => DoSomeWork(1, 500)).ContinueWith((prevTask) => DoSomeOtherWork(1, 700));
            Task.Factory.StartNew(() => DoSomeWork(2, 1500)).ContinueWith((prevTask) => Console.WriteLine(prevTask.IsCompleted));
            Task.Factory.StartNew(() => DoSomeWork(3, 2000));
            Task.Factory.StartNew(() => DoSomeWork(4, 1800));
            
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        static void DoSomeWork(int id, int frequency)
        {
            Console.WriteLine("Task #{0} is starting", id);
            Thread.Sleep(frequency);
            Console.WriteLine("Task #{0} has ended", id);
        }
        static void DoSomeOtherWork(int id, int frequency)
        {
            Console.WriteLine("Other work task #{0} is starting", id);
            Thread.Sleep(frequency);
            Console.WriteLine("Other work task #{0} has ended", id);
        }
    }
}
