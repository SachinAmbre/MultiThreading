using System;
using System.Threading;

namespace A4
{
    class Program
    {
        static object temp = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(TakeTurn);
            t1.Name = "Ping";
            t1.Start();
            Thread t2 = new Thread(TakeTurn);
            t2.Name = "Pong";
            t2.Start();
        }

        static void TakeTurn()
        {
            try
            {
                lock (temp)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} Started");
                    Thread.Sleep(3000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} Stopped");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
