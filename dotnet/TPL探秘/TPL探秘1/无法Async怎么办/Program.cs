using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace 无法Async怎么办
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient hc = new HttpClient();
            #region Main中不支持Async  await
            //HttpResponseMessage msg = await hc.GetAsync("http://127.0.0.1:8011");
            //Console.WriteLine($"msg=" + msg.Content.ReadAsStringAsync()); 
            #endregion
            //异步任务上下文切换  可能导致 死锁  不推荐使用Result
            Task<HttpResponseMessage> taskMsg = hc.GetAsync("http://127.0.0.1:8011");
            HttpResponseMessage msg = taskMsg.Result;//对于一个Task来讲  读取它的Result属性相当于await等待它执行完成
            Task<string> taskRead = msg.Content.ReadAsStringAsync();//异步方法
            string html = taskRead.Result;//
            Console.WriteLine($"内容是\n{html}");
            Console.ReadKey();
        }
    }
}
