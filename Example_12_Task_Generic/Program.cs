using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_12_Task_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> tresult = new Task<int>(n => Sum((int)n), 500); // cancellation token
            tresult.Start();
            tresult.Wait();

            // Get the result (the Result property internally calls Wait) 
            Console.WriteLine("The sum is: " + tresult.Result);   // An Int32 value
            Console.ReadLine();
        }

        private static int Sum(int n) {
            int sum = 0;
            for (int i = 0; i < n; i++) {
                sum += n;
            }
            return sum;
        }
    }

    
}
