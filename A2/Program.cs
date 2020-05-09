using System;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadStartFunction);
            t1.Name = "Eena";
            t1.Start();

            Thread t2 = new Thread(ThreadStartFunction);
            t2.Name = "Meena";
            t2.Start();

            Thread t3 = new Thread(ThreadStartFunction);
            t3.Name = "Dika";
            t3.Start();


            Thread.Sleep(2000);
            Console.WriteLine("I have started the threads");
        }

        static void ThreadStartFunction()
        {
            for (int local = 0; local < 10; local++)
            {
                Console.WriteLine($"Thread={Thread.CurrentThread.Name} local = {local}");
                Thread.Sleep(1000);
            }
        }
    }
}
