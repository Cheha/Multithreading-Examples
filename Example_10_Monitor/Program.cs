using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_10_Monitor
{
    class Program
    {
        static int Total = 0;

        static void Main(string[] args)
        {
            //AddOneMillion();
            //AddOneMillion();
            //AddOneMillion();
            Thread thread1 = new Thread(AddOneMillion);
            Thread thread2 = new Thread(AddOneMillion);
            Thread thread3 = new Thread(AddOneMillion);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine(Total);
            Console.ReadLine();
        }

        static object _lock = new object();
        public static void AddOneMillion()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Monitor.Enter(_lock);
                try
                {
                    Total++;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
                
            }
           
        }
    }
}
