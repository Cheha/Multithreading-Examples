using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_1._5_ParameterizedThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter target number");
            var number = new Number(Convert.ToInt32(Console.ReadLine()));

            Thread t1 = new Thread(number.PrintNumbers);
            t1.Start();
        }
    }

    class Number
    {
        private int _target;

        public Number(int target)
        {
            _target = target;
        }

        public void PrintNumbers()
        {
            for (int i = 0; i < _target; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
