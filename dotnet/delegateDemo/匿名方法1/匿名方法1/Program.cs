using System;

namespace 匿名方法1
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyDel1 d1 = Func1;
            //bool b1 = d1(6, "lcy");
            //匿名方法
            MyDel1 d2 = delegate (int n1, string s1)
            {
                Console.WriteLine($"我是匿名方法:i={n1},s={s1}");
                return true;
            };
            bool b1 = d2(6,"lcy");
            Console.WriteLine(b1);
            Console.ReadKey();
        }

        static bool Func1(int i,string s)
        {
            Console.WriteLine($"i={i},s={s}");
            return true;
        }
    }

    delegate bool MyDel1(int i, string s);
}
