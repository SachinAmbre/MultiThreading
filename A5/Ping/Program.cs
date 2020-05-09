using System;
using System.Threading;

namespace Mutex1
{
    class Program
    {
        static string MutexName = "SharedMutex";
        static Mutex myMutex = new Mutex(false, MutexName);
        static void Main(string[] args)
        {
            Thread.Sleep(5000);
            Thread ping = new Thread(TakeTurn);
            ping.Name = "Ping";
            ping.Start();
        }

        static void TakeTurn()
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    myMutex.WaitOne();
                    Console.WriteLine($"{Thread.CurrentThread.Name} Started");
                    Console.WriteLine($"{Thread.CurrentThread.Name} Stopped");
                    myMutex.ReleaseMutex(); 
                    Thread.Sleep(new Random().Next(1000, 10000));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
