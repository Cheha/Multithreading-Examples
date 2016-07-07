using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrainAcademy.ThreadInterrupt
{
    class Program
    {
        static Thread mother = new Thread(new ThreadStart(MotherSleep));
        static Thread son = new Thread(new ThreadStart(ChildWoke));
        static void Main(string[] args)
        {
            mother.Start();
            son.Start();
            mother.Join();
            son.Join();
            Console.WriteLine("Existing Interrupt");
            Console.ReadLine(); 
        }

        public static void MotherSleep() {
            for (int i = 0; i < 50; i++) {
                Console.Write(" m ");
                if((i % 10 == 0) && (i != 0)) {
                    try {
                        Console.WriteLine("Mother counter control: {0}, thread: {1}", i, 
                            Thread.CurrentThread.ManagedThreadId + " Mother will sleep");
                        Thread.Sleep(20);
                    } catch (ThreadInterruptedException ex) {
                        Console.WriteLine("Mother catch ThreadInterruptedException. Get up!!!");
                    }
                    Console.WriteLine("OK");
                }
            }
        }

        public static void ChildWoke() {
            for (int i = 1; i < 50; i++) {
                Console.WriteLine(" c ");
                if (mother.ThreadState == ThreadState.WaitSleepJoin) { 
                    Console.WriteLine(@"Child check Mother.ThreadState == 
                                    ThreadState.WaitSleepJoin. Interrupting mother");
                    mother.Interrupt();
                }
            }
        }
    }
}
