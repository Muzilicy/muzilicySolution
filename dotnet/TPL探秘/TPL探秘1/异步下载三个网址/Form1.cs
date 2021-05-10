using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 异步下载三个网址
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            //string html1 = await wc.DownloadStringTaskAsync(textBox1.Text);
            //string html2 = await wc.DownloadStringTaskAsync(textBox2.Text);
            //string html3 = await wc.DownloadStringTaskAsync(textBox3.Text);
            //label1.Text = html1.Length.ToString();
            //label2.Text = html2.Length.ToString();
            //label3.Text = html3.Length.ToString();

            //webClient不支持并发操作
            //var task1 = new WebClient().DownloadStringTaskAsync(textBox1.Text);
            //var task2 = new WebClient().DownloadStringTaskAsync(textBox2.Text);
            //var task3 = new WebClient().DownloadStringTaskAsync(textBox3.Text);
            //Task.WaitAll(task1, task2, task3);

            //label1.Text = task1.Result.Length.ToString();
            //label2.Text = task2.Result.Length.ToString();
            //label3.Text = task3.Result.Length.ToString();
            
            //支持多线程
            HttpClient hc = new HttpClient();
            var task1 = hc.GetStringAsync(textBox1.Text);
            var task2 = hc.GetStringAsync(textBox2.Text);
            var task3 = hc.GetStringAsync(textBox3.Text);
            Task.WaitAll(task1, task2, task3);
            label1.Text = task1.Result.Length.ToString();
            label2.Text = task2.Result.Length.ToString();
            label3.Text = task3.Result.Length.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
