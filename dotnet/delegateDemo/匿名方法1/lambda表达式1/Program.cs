using System;

namespace lambda表达式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> a1 = delegate (int i)
            {
                Console.WriteLine(i);
            };
            Action<int> a2 = (int i) =>
            {
                Console.WriteLine($"lambda表达式的匿名的写法：{i}");
            };

            Action<int> a3 = i => { Console.WriteLine($"lambda表达式的匿名的写法:去掉小括号---{i}"); };
            //a3(1111111);

            //a1(222);
            //a2(22222);
            Func<string, int, bool> f1 = delegate (string s, int i)
              {
                  Console.WriteLine($"s={s},i={i}");
                  return true;
              };
            Func<string, int, bool> f2 = (string s, int i) =>
            {
                Console.WriteLine($"lambda表达式：s={s},i={i}");
                return true;
            };

            Func<string, int, bool> f3 = (s, i) =>
              {
                  return true;
              };

            Func<string, int, bool> f4 = (s, i) => true;//代码只有一行且有返回值，可省略成这样
            bool b3 = f4("111",1111111);//f3("lll", 111);
            Console.WriteLine(b3);
            Console.ReadKey();
           
        }
    }
}
