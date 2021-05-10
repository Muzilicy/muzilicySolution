using System;
using System.ComponentModel;

namespace 单例模式Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region 饿汉单例模式  多线程也能用
    class God
    {
        /// <summary>
        /// 2、唯一对象
        /// </summary>
        private static God instance = new God();
        /// <summary>
        /// 1、构造函数私有
        /// </summary>
        private God()
        {

        }
        /// <summary>
        /// 外部接口提供对象
        /// </summary>
        public God GetInstance()
        {
            return instance;
        }

    }
    #endregion

    #region 懒汉单例模式   存在线程安全
    class Person
    {
        private static Person instance = null;
        private Person() { }

        //也可将此方法标注成同步方法[MethodImpl(MethodImplOptions.Synchronized)]  实现线程安全
        public static Person GetInstance() //必须声明为static 类调用
        {
            if(instance == null)
            {
                instance = new Person();
            }
            return instance;
        }
    }
    #endregion

    #region 单例模式 线程安全的  此处可能造成性能问题

    class Employee
    {
        private static object locker = new object();//locker对象

        private static Employee instance = null;

        private Employee()
        {

        }

        /// <summary>
        /// 可能性能比较低  每次进来都枷锁
        /// </summary>
        /// <returns></returns>
        public static Employee GetInstance() //必须声明为static 类调用
        {
            lock (locker)
            {
                if(instance == null)
                {
                    instance = new Employee();
                }
                return instance;
            }
        }
    }
    #endregion


    #region 单例模式 线程安全   第一次初始化时创建对象  性能好
    class Orglist
    {
        private static Orglist instance = null;
        private static object locker = new object();
        private Orglist() { }

        public static Orglist GetInstance() //必须声明为static 类调用
        {
            if (instance == null) //第一次进来才对象赋值
            {
                lock (locker)
                {
                    if(instance == null)
                    {
                        instance = new Orglist();
                    }
                }
            }
            return instance;
        }
    }
    #endregion
}
