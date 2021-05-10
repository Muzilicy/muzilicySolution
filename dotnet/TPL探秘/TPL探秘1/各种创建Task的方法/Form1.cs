using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 各种创建Task的方法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //调用的时候也需要async   await
        private async void button1_Click(object sender, EventArgs e)
        {
            string html = await GetSelfAync();
            MessageBox.Show(html);
        }

        //缓存
        static string cacheHtml;

        //async   return 就是string
        //不加async  return 就是一个Task<string>没有await
        static async Task<string> GetSelfAync()
        {
            if(cacheHtml != null)
            {
                return cacheHtml;
            }
            else
            {
                HttpClient hc = new HttpClient();
                var msg = await hc.GetAsync("http://127.0.0.1:8011");
                string html = await msg.Content.ReadAsStringAsync();
                cacheHtml = html;
                return html;
            }
            
        }

        //不管调用的方法是async Task<int> 
        //还是Task<int>  调用者均需要标注async   await
        private async void button2_Click(object sender, EventArgs e)
        {
            //int i = await F1Async();
            int i = await F2Async();
            MessageBox.Show(i.ToString());

        }

        static Task<int> F1Async()
        {
            //return Task.Run(() => {
            //    return 1;
            //});
            return Task.FromResult(2);
        }

        static async Task<int> F2Async()
        {
            Task<int> task = Task.Run(() => {
                return 1;
            });
            return await task;
        }

        static Task<int> F3Async(int i)
        {
            if (i == 3)
            {
                return Task.FromResult(4);
            }
            //else if(i==5)
            //{
            //    //return Task.Delay(2000);
            //}
            else
            {
                return Task.Run(() =>
                {
                    return 7;
                });
            }
        }
    }
}
