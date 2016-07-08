using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_15_APM
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncCallback callBack = new AsyncCallback(EndGetNumSum);
            IAsyncResult result = BeginGetNumSum(4, 8, callBack, new object());
            EndGetNumSum(result);
     
        }

        private delegate int GetNumSumHandler(int min, int count);
        private static GetNumSumHandler getNumSumCaller;

        public static int GetNumSum(int min, int count)
        {
            return ParallelEnumerable.Range(min, count).Sum(x => x);
        }

        public static IAsyncResult BeginGetNumSum(int min, int count,
            AsyncCallback callback, object userState) {
                getNumSumCaller = GetNumSum;
                return getNumSumCaller.BeginInvoke(min, count, callback, userState);
        }

        public static void EndGetNumSum(IAsyncResult result) {
            int res = getNumSumCaller.EndInvoke(result);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
