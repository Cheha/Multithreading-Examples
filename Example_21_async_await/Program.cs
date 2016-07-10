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
            Task<int> longRunningTask = LongRunningOperationAsynk();

            int result = await longRunningTask;
            Console.WriteLine(result);
        }

        public static async Task<int> LongRunningOperationAsynk()
        {
            Thread.Sleep(2000);
            return 2;
        }
    }
}
