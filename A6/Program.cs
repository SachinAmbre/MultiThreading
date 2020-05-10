using System;
using System.Threading;

namespace A6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to Insert or 2 to Update");
            int param = Convert.ToInt32(Console.ReadLine());
            Thread th = new Thread(new ParameterizedThreadStart(UpdateDtls));
            th.Start(param);

            Console.WriteLine("Main Ends");
        }

        static void UpdateDtls(object value)
        {
            if (Convert.ToInt32(value) == 1)
                //Insert in database
                Console.WriteLine("Inserting into datbase...");
            else
                Console.WriteLine("Updating datbase...");

            Thread.Sleep(2000);

        }
    }
}
