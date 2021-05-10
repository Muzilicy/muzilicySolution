using System;
using System.Collections.Generic;
using System.Text;

namespace 集合扩展方法01
{
    static class MyEx
    {
        public static int MySum<T>(this IEnumerable<T> data,Func<T,int> func)
        {
            int sum = 0;
            foreach (T item in data)
            {
                sum += func(item);
            }
            return sum;
        }
    }
}
