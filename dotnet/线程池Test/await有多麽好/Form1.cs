using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace await有多麽好
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //TPL风格的
        private async void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string s = await wc.DownloadStringTaskAsync("https://www.keybr.com/");
            textBox1.Text = s;
            string s2 = await wc.DownloadStringTaskAsync("http://www.baidu.com");
            MessageBox.Show(s2);
        }

        //异步方法   tpl风格
        private async void button2_Click(object sender, EventArgs e)
        {
            using(FileStream fs = File.OpenRead("d:/1.txt"))
            {
                byte[] buffer = new byte[50];
                await fs.ReadAsync(buffer, 0, buffer.Length);
                string s = Encoding.UTF8.GetString(buffer);
                textBox1.Text = s;
            }
        }

        /// <summary>
        /// 异步方法的编写
        /// </summary>
        /// <returns></returns>
        static Task<string> TaskAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Sunshine";
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string s = await TaskAsync();
            textBox1.Text = s;
        }
    }
}
