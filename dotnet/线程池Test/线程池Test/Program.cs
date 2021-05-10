using System;
using System.Threading;

namespace 线程池Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(state =>
            //{
            //    for (int i = 0; i < 200; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});

            //for (int i = 0; i < 200; i++)
            //{
            //    Console.WriteLine("hello");
            //}

            for (int i = 0; i < 30; i++)
            {
                //委托丢给ThreadPool
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Console.WriteLine(state);
                    int workThread, compleportThreads;
                    ThreadPool.GetAvailableThreads(out workThread, out compleportThreads);
                    Console.WriteLine($"workThread={workThread},compleportThreads={compleportThreads}");
                },i);
            }

            Console.ReadKey();
        }
    }
}
