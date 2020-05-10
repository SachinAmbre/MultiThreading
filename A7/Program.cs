using System;
using System.Threading;

namespace ThreadingWays
{
    class Another
    { 
        public void InstanceMethod()
        {
            Console.WriteLine("Hello from Instance method");
        }

        public (int, string, bool) MultiReturnFunction()
        {
            return (1,"Hello", false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread staticMethod = new Thread(StaticMethod);
            staticMethod.Start();

            Another anotherObject = new Another();
            Thread instanceMethod = new Thread(anotherObject.InstanceMethod);
            instanceMethod.Start();

            Thread delegateMethod = new Thread(delegate() { Console.WriteLine("Hello from delegate"); });
            delegateMethod.Start();

            Thread lambdaMethod = new Thread(() => Console.WriteLine("Hello from lambda"));
            lambdaMethod.Start();

            Thread threadStartMethod = new Thread(new ThreadStart(ThreadStartMethod));
            threadStartMethod.Start();

            Thread parameterMethod = new Thread(new ParameterizedThreadStart(ParamMethod));
            parameterMethod.Start("Hello");
        }

        static void StaticMethod()
        {
            Console.WriteLine("Hello from Satic Method!");
        }

        static void ThreadStartMethod()
        {
            Console.WriteLine("calling using new ThreadStart!");
        }

        static void ParamMethod(object obj)
        {
            if (obj == null)
            {
                throw new Exception("No Data");
            }
            Console.WriteLine($"Parameter received {obj}");
        }
    }
}
