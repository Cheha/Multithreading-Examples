using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_ThreadManipulator
{
    public class ThreadManipulator
    {
        private ConsoleKey _key;
        private static readonly object _block = new object();


        public void AddingOne(object target)
        {
            var number = Convert.ToInt32(target);
            var threadId = Thread.CurrentThread.ManagedThreadId;
            lock (_block)
            {
                for (var i = 0; i < 100 && _key != ConsoleKey.Q; i++)
                {
                    if (i % number == 0)
                    {
                        Console.WriteLine("{0} is divisible by {1}. " +
                                          "AddingOne, ManagedThreadId = {2}", i, number, threadId);
                        Thread.Sleep(500);
                    }
                }
            }
        }

        public void AddingCustomValue(object target)
        {
            var args = target as CustomValueArgs;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            lock (_block)
            {
                for (var i = 0; i < 100 * args?.Step && _key != ConsoleKey.W; i += args.Step)
                {
                    if (i % args.Number == 0)
                    {
                        Console.WriteLine("{0} is divisible by {1}. " +
                                          "AddingCustomValue, ManagedThreadId = {2}", i, args.Number, threadId);
                        Thread.Sleep(500);
                    }
                }
            }
        }

        public void Stop()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            while (true)
            {
                _key = Console.ReadKey().Key;
                Console.WriteLine("Stop, ManagedThreadId = {0}", threadId);
            }
        }
    }
}
