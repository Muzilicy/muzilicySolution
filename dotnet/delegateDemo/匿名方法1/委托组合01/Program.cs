using System;

namespace 委托组合01
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDel d1 = F1;
            MyDel d2 = F2;
            MyDel d3 = F3;


            MyDel d4 = d1 + d2 + d3;

            MyDel d5 = new MyDel(F1) + new MyDel(F3) + new MyDel(F2);

            Console.WriteLine("委托F1+F2+F3:");
            d4(20);
            Console.WriteLine("委托F1+F3+F2:");
            d5 -= new MyDel(F3);
            d5(20);


            Console.ReadKey();
        }


        static void F1(int i)
        {
            Console.WriteLine("我是F1" + i);
        }

        static void F2(int i)
        {
            Console.WriteLine("我是F2" + i*2);
        }


        static void F3(int i)
        {
            Console.WriteLine("我是F3" + i * 3);
        }
    }

    delegate void MyDel(int i);
}
