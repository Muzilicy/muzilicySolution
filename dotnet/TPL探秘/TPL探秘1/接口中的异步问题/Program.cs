using System;
using System.Threading.Tasks;

namespace 接口中的异步问题
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface ITest
    {
        Task<string> GetAsync(int i);
    }

    public class Test : ITest
    {
        //public Task<string> GetAsync(int i)
        //{
        //    return Task.FromResult("aaa"); //返回值是Task<string>类型
        //}

        public async Task<string> GetAsync(int i)
        {
            return await Task.Run(() =>
            {
                return "aaaa";
            });
        }
    }
}
