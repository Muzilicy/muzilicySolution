using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace WordCountTest
{
    /// <summary>
    /// 题目：给定一个目录，统计该目录及其子目录
    /// 下所有文件内容中的词频，并输出最多的词频。
    /// 假设所有的文件都是txt格式，
    /// 且所有的内容都是英文。
    /// 
    /// 分析：
    /// 1、可以使用Dictionary来存储每个词的出现次数
    /// 2、时间复杂度至少为O(n）
    /// 我们可以通过多线程来进行并行处理
    /// C#多线程
    /// </summary>
    class Program
    {
        static object _sync = new object();//锁

        static int _unreadFileCount; //未阅读的文件数量

        static AutoResetEvent _event = new AutoResetEvent(false);
        //统计每个单词的出现的个数
        static Dictionary<string, int> wordCount = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string path = @"D:\test\data";//The_Man_of_Property.txt

            //获取当前路径下的所有的子目录和下级目录的文件
            List<FileInfo> files = getFiles(path);

            _unreadFileCount = files.Count;

            //异步遍历读取所有的文件
            foreach (var file in files)
            {
                CountWordsAsync(file);
            }

            _event.WaitOne();//等待_event.Set()释放资源之后  进行下面的操作
                             //======确保所有的文件均已读取完毕=====

            //遍历字典，获取出现次数最大的前10个词
            int i = 0;
            foreach (var kv in wordCount.OrderByDescending(o=>o.Value))
            {
                Console.WriteLine($"{kv.Key}:{kv.Value}");

                i++;
                
                if(i > 100)
                {
                    break;
                }
            }

            Console.ReadKey();
            
            //Console.WriteLine("Hello World!");
        }

        static async void CountWordsAsync(FileInfo file)
        {
            try
            {
                //文件的读取
                //file.FullName  文件的路径
                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    StringBuilder word = new StringBuilder();//字符串拼接效率高
                    string line = string.Empty;//中间变量记录每行的数据
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Check(line[i]))
                            {
                                //是字母或者数字的话append
                                word.Append(line[i]);
                            }
                            else
                            {
                                //如果当前的字符不是字母或者数字【可能是回车  也可能是空格】
                                //就需要统计当前单词的个数
                                //统计之前现需要判断该词是否已经在字典中，
                                //存在则累加 不存在则加入字典中，count记为1
                                if (word.Length > 0)//不可少
                                {
                                    //当前词长度大于1
                                    //转换--中间变量
                                    string words = word.ToString();
                                    lock (_sync)
                                    {
                                        //加锁，多线程并发控制
                                        if (!wordCount.ContainsKey(words))
                                        {
                                            //不存在当前词  则添加到字典中  count记为1
                                            wordCount[words] = 1;
                                        }
                                        else
                                        {
                                            wordCount[words]++;
                                        }
                                        //统计完当前单词之后将word置空
                                        word.Clear();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            lock (_sync)
            {
                _unreadFileCount--;
                if(_unreadFileCount == 0)
                {
                    _event.Set();//释放该资源
                }
            }
            
        }
        //C#中的Char.IsLetterOrDigit()方法
        //指示将指定的Unicode字符分类为字母还是十进制数字。
        static bool Check(char c)
        {
            return char.IsLetterOrDigit(c);
        }
        static List<FileInfo> getFiles(string path)
        {
            List<FileInfo> files = new List<FileInfo>();
            //当前目录对象
            DirectoryInfo di = new DirectoryInfo(path);
            files.AddRange(di.GetFiles());//将当前目录下的所有的文件添加到集合中
            foreach (var d in di.GetDirectories()) //遍历当前目录的所有子目录
            {
                //并且一次将下级文件依次添加到files中
                files.AddRange(getFiles(path + @"\" + d.Name));//d.Name是文件夹名称
            }

            return files;
        }
    }
}
