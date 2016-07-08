using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_14_Parallel_Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Hello, Johny");
            }, () =>
            {
                Console.WriteLine("Hello, Mary");
            }, () =>
            {
                Console.WriteLine("Hello, Bob");
            });
            Console.ReadLine();
        }
    }
}
