using System;
using System.Threading;

namespace 线程同步问题
{
    class Program
    {
        private static int counter = 0;
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        counter++;
            //        Thread.Sleep(1);
            //    }
            //});
            //t1.Start();
            //Thread t2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        counter++; //counter = count + 1;
            //        Thread.Sleep(1);
            //    }
            //});
            //t2.Start();
            ////等待线程结束运行
            //while (t1.IsAlive) { };
            //while (t2.IsAlive) { };


            for(int i = 0;i < 10;i++)
            {
                for(int j = 0;j <20;j++)
                {
                    if(i == j)
                    {
                        break;
                    }
                }
                Console.WriteLine(11111);//1989
            }
            Console.WriteLine(counter);//1989
            Console.ReadKey();
        }
    }
}
