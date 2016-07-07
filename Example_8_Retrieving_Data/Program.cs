using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_8_Retrieving_Data
{
    public delegate void SumOfNumDelegate(int sumOfNum);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a target number");
            int target = Convert.ToInt16(Console.ReadLine());

            SumOfNumDelegate callback = new SumOfNumDelegate(PrintSum);

            var number = new Number(target, callback);
            Thread thread = new Thread(number.PrintSumOfNumbers);
            thread.Start();
        }

        public static void PrintSum(int sum) {
            Console.WriteLine("Sum of numbers = {0}", sum);
            Console.ReadLine();
        }
    }

    class Number
    {
        int _target;
        SumOfNumDelegate _callback;
        public Number(int target, SumOfNumDelegate callback)
        {
            this._target = target;
            this._callback = callback;
        }

        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i < this._target; i++)
            {
                sum += i;
            }
            if (_callback != null) {
                this._callback(sum);
            }
        }
    }
}
