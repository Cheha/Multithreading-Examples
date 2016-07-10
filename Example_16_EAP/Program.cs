using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_16_EAP
{

    class Calculator
    {
        public bool IsBusy { get; set; }

        public delegate void GetNumSumCompletedEventHandler(object sender, GetNumSumCompletedEventArgs e);
        public class GetNumSumCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
        {
            public int Result;
        }

        public static int GetNumSum(int min, int count) // Syncronous operation
        {
            return Enumerable.Range(min, count).Sum(x => x);
        }

        public static void GetNumSumAsync(int min, int count)
        {

        }

        public static void GetNumSumAsync(int min, int count, object userState)
        {

        }

        public static void CancelAsync()
        {
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            var result = GetNumSum(4, 7);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        
    }
}
