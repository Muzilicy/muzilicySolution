using System;

namespace 匿名方法2_改造GetMax_
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] nums = new object[] { 1, 2, 4, 14 };
            CompareFunc func1 = delegate (object o1, object o2)
            {
                int i1 = (int)o1;
                int i2 = (int)o2;
                return i1 > i2;
            };

            object maxVal = GetMax(nums, func1);
            Console.WriteLine($"最大值为{maxVal}");
            Console.ReadKey();
        }

        static object GetMax(object[] nums,CompareFunc func)
        {
            object max = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                //调用func指向的方法，判断谁大
                //写这段代码的人也不知道func指向那个方法，
                //只知道func指向的方法，有两个object参数，一个bool返回值
                if (func(nums[i], max))
                {
                    max = nums[i];
                }
            }
            return max;
        }
    }

    delegate bool CompareFunc(object i1, object i2);
}
