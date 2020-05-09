using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadStartFunction);
            t1.Start();
            Thread.Sleep(2000);
            Console.WriteLine("I have started the thread");
        }

        static void ThreadStartFunction()
        {
            for (int local = 0; local < 10; local++)
            {
                Console.WriteLine($"local = {local}");
                Thread.Sleep(1000);
            }
        }
    }
}
