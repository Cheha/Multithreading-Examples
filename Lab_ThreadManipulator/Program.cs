using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_ThreadManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var manipulator = new ThreadManipulator();

            var addOneThr1 = new Thread(manipulator.AddingOne);
            var addOneThr2 = new Thread(manipulator.AddingOne);

            var addCustThr = new Thread(manipulator.AddingCustomValue);

            var stopThr = new Thread(manipulator.Stop) { IsBackground = true };

            stopThr.Start();

            addOneThr1.Start(10);
            addOneThr2.Start(20);
            // addCustThr.Start( new[]{15, 5} );
            addCustThr.Start(new CustomValueArgs() { Number = 5, Step = 15});
            addOneThr1.Join();
            addOneThr2.Join();
            addCustThr.Join();

            Console.ReadKey();
        }
    }
}
