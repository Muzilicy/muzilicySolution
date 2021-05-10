using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWhere
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] nums = new int[] { 3, 4, 114, 11, 555, 12, 4 };
            IEnumerable<int> r1 = nums.MyWhere(i => i % 2 == 0);//delegate(i){return i > 10;};
            foreach (int item in r1)
            {
                Console.WriteLine(item);
            }*/

            string[] strs = new string[] { "licy", "sina", "kelly", "Tim", "John" };

            foreach(string str in strs.MyWhere(d => d.Length == 4))
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
