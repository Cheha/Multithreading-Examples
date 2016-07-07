using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace BrainAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(new Action(PrintMessage));
            Task task2 = new Task(delegate { PrintMessage(); });
            Task task3 = new Task(() => PrintMessage());
            Task task4 = new Task(() => { PrintMessage(); });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            Console.WriteLine("Main method complete. Press <enter> to finish.");
            Console.ReadLine();

        }

        private static void PrintMessage() {
            Console.WriteLine("Hello, world {0}");
        }
    }
}
