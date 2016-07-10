using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_20_TaskCancelation
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            try
            {
                var t1 = Task.Factory.StartNew(() => DoSomeWork(1, 1000, source.Token));
                source.Cancel();
            }
            catch (Exception ex) {
                Console.WriteLine("Error");
            }
            Console.ReadLine();
        }

        static void DoSomeWork(int id, int frequency, CancellationToken token)
        {
            if (token.IsCancellationRequested) {
                Console.WriteLine("Cancelation requested");
                token.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Task #{0} is starting", id);
            Thread.Sleep(frequency);
            Console.WriteLine("Task #{0} has ended", id);
        }
    }
}
