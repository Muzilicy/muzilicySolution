using System;

namespace lambda表达式改造GetMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 3, 4, 5, 2, 111 };
            //1.具体方法
            //int m = GetMax(nums, compareInt);
            //2.匿名方法
            /*int m = GetMax(nums, delegate (int i1, int i2)
             {
                 return i1 > i2;
             });*/
            //3.lambda表达式
            //int m = GetMax(nums, (i1, i2) => i1 > i2);
            //Console.WriteLine(m);

            Person[] persons = new Person[]
            {
                new Person("lcy",27),
                new Person("yzk",37),
                new Person("lll",122)
            };

            Person p = GetMax(persons, ( p1, p2) => p1.Age > p2.Age);

            Console.WriteLine(p);

            Console.ReadKey();
        }

        static bool compareInt(int i1,int i2)
        {
            return i1 > i2;
        }

        static T GetMax<T> (T[] objs,Func<T,T,bool> compareFunc)
        {
            T max = objs[0];

            for(int i = 0; i < objs.Length; i++)
            {
                if(compareFunc(objs[i],max))
                {
                    max = objs[i];
                }
            }

            return max;
        }
    }


    class Person
    {
        public Person(string name,int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"age={this.Age},Name={this.Name}";
        }
    }

}
