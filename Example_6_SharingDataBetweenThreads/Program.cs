using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example_6_SharingDataBetweenThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Msg_Back message = new Msg_Back();
            message.Msg = "Are you here?";
            new Thread(message.Reply).Start();
            Console.WriteLine("Press any key");
            Console.ReadLine();
            Console.WriteLine(message.Answ);
            Console.ReadLine();
        }

        public class Msg_Back
        {
            public string Msg;
            public string Answ;
            public void Reply() {
                Console.WriteLine("Worker thread. Msg field: " + Msg);
                Answ = "Yes";
            }
        }
    }
}
