using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_17_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => DoSomeWork(1, 1500));
            Task task2 = new Task(() => DoSomeWork(2, 1700));
            Task task3 = new Task(() => DoSomeWork(3, 500));
            Task task4 = new Task(() => DoSomeWork(4, 1000));

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            Console.ReadLine();
        }

        static void DoSomeWork(int id, int frequency)
        {
            Console.WriteLine("Task #{0} is starting", id);
            Thread.Sleep(frequency);
            Console.WriteLine("Task #{0} has ended", id);
        }

    }
}
