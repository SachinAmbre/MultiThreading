using System;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static Semaphore plaground = new Semaphore(2, 2);
        static string[] Players = { "Sachin", "Virat", "Rohit", "Ravindra", "Yuvraj", "Dhoni", "Bumrah" };
        static void Main(string[] args)
        {
            foreach (var Player in Players)
            {
                Thread cricketThread = new Thread(GoPlay);
                cricketThread.Name = Player;
                cricketThread.Start();
            }
        }

        static void GoPlay()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is Waiting..");
            plaground.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} is Playing..");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} hit Century..");
            Thread.Sleep(new Random().Next(2000, 10000));

            Console.WriteLine($"{Thread.CurrentThread.Name} is Out..");
            plaground.Release();
        }
    }
}
