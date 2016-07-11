using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_21_async_await
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMethodAsyck();
            Console.ReadLine();
        }

        public static async Task MyMethodAsyck() {
            Task<int> longRunningTask = LongRunningOperationAsync();

            int result = await longRunningTask;
            Console.WriteLine(result);
        }

        public static async Task<int> LongRunningOperationAsync()
        {
            Console.WriteLine("Start long running task");
            Thread.Sleep(3000);
            Console.WriteLine("End long running task");
            return 2;
        }
    }
}
