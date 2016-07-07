using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_7_Passing_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a target number");
            int target = Convert.ToInt16(Console.ReadLine());

            var number = new Number(target);
            Thread thread = new Thread(number.PrintNumbers);
            thread.Start();
        }
    }

    class Number {
        int _target;
        public Number(int target) {
            this._target = target;
        }

        public void PrintNumbers() {
            for (int i = 0; i < this._target; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
