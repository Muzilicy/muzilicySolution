using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 扩展IEnumerable<T>的方法，
/// 使继承了IEnumerable<T>的接口有了MyWhere方法
/// 要求：必须是静态类+必须是静态方法+(this添加到IEnumerable<T>之前修饰）
///       表示扩展
/// </summary>
namespace MyWhere
{
    //必须是静态类
    static class CollectionExt
    {
        
        //必须是静态方法
        public static IEnumerable<T> MyWhere<T> (this IEnumerable<T> data,Func<T,bool> func)
        {
            //foreach（）面试题：什么样的对象可以使用foreach遍历？
            // 实现了IEnumerable接口
            // List、数组等都实现了IEnumerable接口

            List<T> resultList = new List<T>();

            foreach(T item in data)
            {
                if (func(item))//判断遍历到的这条数据是否满足条件func
                {
                    resultList.Add(item);
                }
            }

            return resultList;
        }
    }
}
