using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace 线程同步深入1
{
    class Program
    {
        static int money = 10000;
        //lock只能lock引用类型  同一个对象
        private static object locker = new object();//定义一个对象  lock操作

        #region 方法2加特性
        /// <summary>
        /// 标注特性 
        /// [MethodImpl(MethodImplOptions.Synchronized)]
        /// 含义：
        /// 这样一个方法只能同时被一个线程访问   同步方法
        /// 
        /// 线程安全：可以多个方法调用不会混乱  线程不安全同理
        /// </summary>
        /// <param name="name"></param>
        ///[MethodImpl(MethodImplOptions.Synchronized)] 
        #endregion
        static void QuQian(string name)
        {
            #region 方法一加锁  第一处或者加载方法里面
            //lock (locker) //方法一加锁  第一处或者加载方法里面
            //{
            //    Console.WriteLine($"{name}查看一下余额{money}");
            //    int yue = money - 1;
            //    Console.WriteLine($"{name}取钱");
            //    money = yue; //故意这样写，写成money --其实就没有问题
            //    Console.WriteLine($"{name}取完了,剩{money}");
            //} 
            #endregion

            //lock实际上就是调用Monitor来实现的
            Monitor.Enter(locker);//等待没有人锁定locker对象，我就锁定它，然后继续执行
            try
            {
                Console.WriteLine($"{name}查看一下余额{money}");
                int yue = money - 1;
                Console.WriteLine($"{name}取钱");
                money = yue; //故意这样写，写成money --其实就没有问题
                Console.WriteLine($"{name}取完了,剩{money}");
            }
            finally
            {
                Monitor.Exit(locker);//释放locker对象的多
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    #region 方法一加锁  第一处或者加载方法里面
                    //lock (locker)
                    //{
                    //    QuQian("t1");
                    //} 
                    #endregion

                    QuQian("t1");
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    #region 方法一加锁
                    //lock (locker)
                    //{
                    //    QuQian("t2");
                    //} 
                    #endregion

                    QuQian("t2");
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            //Console.WriteLine($"余额{money}"); //8207   线程同步问题  需要用加锁lock
            Console.WriteLine($"余额{money}"); //8000
            Console.ReadKey();
        }
    }
}
