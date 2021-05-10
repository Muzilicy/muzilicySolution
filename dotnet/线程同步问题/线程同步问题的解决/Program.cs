using System;
using System.Threading;

namespace 线程同步问题的解决
{
    /// <summary>
    /// 改用 lock 解决多个线程同时操作一个资源。 lock 是 C#中的关键字，他要锁定一个资源， lock 的
    ///特点是：同时只能有一个线程进入 lock 的对象的范围，其他 lock 的线程就要等
    /// </summary>
    class Program
    {
        private static int counter = 0;
        //锁
        private static object locker = new object();
        //private static object locker2 = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker) //lock+锁对象  同时只有一个线程锁定一个对象
                    {
                        counter++;
                    }

                    //Thread.Sleep(1);
                }
            });

            t1.Start();

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                    //Thread.Sleep(1);
                }
            });

            t2.Start();
            //t1.join()是判断t1的active状态
            t1.Join();//线程同步  使得线程之间的并行执行变成串行执行
            t2.Join();
            #region 作用同上
            //while (t1.IsAlive) { };
            //while (t2.IsAlive) { }; 
            #endregion
            Console.WriteLine(counter);

            Console.ReadKey();
        }
    }
}
