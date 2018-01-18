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
            object target = Console.ReadLine();

            var number = new Number();
            //ParameterizedThreadStart parameterizedThreadStart 
            //    = new ParameterizedThreadStart(number.PrintNumbers);
            Thread t1 = new Thread(number.PrintNumbers);
            t1.Start(target);
        }
    }

    class Number
    {
        public void PrintNumbers(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(),out number))
            {
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
        }
    }
}
