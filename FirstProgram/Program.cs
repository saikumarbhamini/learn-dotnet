/*
Multithreading: Every program by default has a single thread called main thread that executes the program.
    - Every program by default is single threaded.
    - We use Thread class from System.Threading namespace to create threads for each method.
    - Threads are always void return type.
    - We use ParameterizedThreadStart to create thread that takes parameters for the method it 
    is bind to.
    - We use Join statement to make sure that main thread doesn't finish before sub threads it has created finishes.
Thread locking: Its a concept where a block of code is only accessible to only one thread, to make sure 
    one thread action doesn't affect expected result of another thread.

*/
using System.Diagnostics;

namespace FirstProgram
{
    class Program
    {
        static void Test1(object max)
        {
            Console.WriteLine("Thread 1 started");
            int num = Convert.ToInt32(max);
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine("Thread-1: " + i);
            }
            Console.WriteLine("Thread 1 ended");
        }
        static void Test2()
        {
            Console.WriteLine("Thread 2 started");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Thread-2: " + i);
            }
            Console.WriteLine("Thread 2 ended");
        }
        static void Test3()
        {
            Console.WriteLine("Thread 3 started");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Thread-3: " + i);
                if (i == 50)
                {
                    Console.WriteLine("Sleeping....");
                    Thread.Sleep(5000);
                }
            }
            Console.WriteLine("Thread 3 ended");
        }
        static void IncrementCounter1()
        {
            long Counter = 0;
            for (long i=0; i <= 10000000000; i++)
                Counter++;
            Console.WriteLine("Count1" + Counter);
        }
        static void IncrementCounter2()
        {
            long Counter = 0;
            for (long i=0; i <= 10000000000; i++)
                Counter++;
            Console.WriteLine("Count2" + Counter);
        }
        public void Display()
        {
            lock (this)
            {
                Console.Write("[Welcome to");
                Thread.Sleep(2000);
                Console.WriteLine(" the Kite festival.]");
            }

        }

        static void Main()
        {
            Console.WriteLine("Main thread started");
            // ThreadStart td = new(Test1);
            ParameterizedThreadStart td = Test1;
            // ThreadStart td = delegate(){Test1();};
            // ThreadStart td = () => Test1();
            Thread t1 = new(td);
            Thread t2 = new(Test2);
            Thread t3 = new(Test3);
            t1.Start(45);
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Program P = new();
            Thread t4 = new(P.Display);
            Thread t5 = new(P.Display);
            Thread t6 = new(P.Display);

            t4.Start();
            t5.Start();
            t6.Start();

            t4.Join();
            t5.Join();
            t6.Join();

            // Checking performance of multithreading vs single threading
            Thread t7 = new(IncrementCounter1);
            Thread t8 = new(IncrementCounter2);
            
            Stopwatch s1 = new();
            Stopwatch s2 = new();

            s1.Start();
            IncrementCounter1();
            IncrementCounter2();
            s1.Stop();

            s2.Start();
            t7.Start();
            t8.Start();
            s2.Stop();
            t7.Join();
            t8.Join();
            Console.WriteLine("Time elapsed for single threaded:" + s1.ElapsedMilliseconds);
            Console.WriteLine("Time elapsed for multi threaded:" + s2.ElapsedMilliseconds);
            Console.WriteLine("Main thread ended");
        }
    }
}
