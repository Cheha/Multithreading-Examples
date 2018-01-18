using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_10._1_Deadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountA = new Account("Alex", 5000);
            var accountB = new Account("John", 10000);

            var t1 = new Thread(accountA.Transfer);
            var t2 = new Thread(accountB.Transfer);

            t1.Start(accountB);
            t2.Start(accountA);
        }
    }

    public class Account
    {
        private decimal _amount;
        private string _name;

        public Account(string name, decimal amount)
        {
            _amount = amount;
            _name = name;
        }
        static object _lock = new object();
        public void Transfer(object accountTo)
        {
            var current = accountTo as Account;
            lock (accountTo)
            {
                _amount = _amount - 100;
                Thread.Sleep(5000);


            }
        }
    }
}
