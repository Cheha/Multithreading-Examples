using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_13_ParalellFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using C# For Loop \n");

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }

            Console.WriteLine("\nUsing Parallel.For \n");
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });

            int[] numArray = new int[] { 0,1,2,3,4,5,6,7,8,9,10 };
            Console.WriteLine("\nUsing Parallel.ForEach \n");
            Parallel.ForEach(numArray, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });

            int[] nums = Enumerable.Range(0, 10).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                        {
                                            subtotal += j; //modify local variable
                                            Console.WriteLine("j: {0}", j);
                                            Console.WriteLine("subtotal: {0}", subtotal);
                                            Console.WriteLine("Current Thread: {0}", Thread.CurrentThread.ManagedThreadId);
                                            return subtotal; // value to be passed to next iteration
                                        },
                // Method to be executed when each partition has completed.
                // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => {
                                            Console.WriteLine("finalResult: {0}", finalResult);
                                            Interlocked.Add(ref total, finalResult); }
                                        );

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);

            Console.ReadLine();
        }
    }
}
