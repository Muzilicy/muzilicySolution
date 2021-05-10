using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程再winform的应用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WebClient wc = new WebClient();
            //string html = wc.DownloadString("https://www.rupeng.com");
            //textBox1.Text = html;

            ThreadPool.QueueUserWorkItem(state =>
            {
                WebClient wc = new WebClient();
                string html = wc.DownloadString("https://www.baidu.com");

                //委托  耗时操作
                //BeginInvoke就是把代码放到UI线程执行
                //textBox1.BeginInvoke(new Action(() =>
                //{
                //    textBox1.Text = html;
                //}));
                //把与界面有关的操作放到UI线程执行
                this.BeginInvoke(new Action(() =>
                {
                    textBox1.Text = html;
                }));
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                
                //把与界面有关的操作放到UI线程执行
                this.BeginInvoke(new Action(() =>
                {
                    WebClient wc = new WebClient();
                    string html = wc.DownloadString("https://www.baidu.com");
                    textBox1.Text = html;
                }));
            });
        }
    }
}
