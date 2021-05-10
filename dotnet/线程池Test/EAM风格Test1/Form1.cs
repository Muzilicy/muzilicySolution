using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EAM风格Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            //异步  执行完成之后 执行completed事件
            wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri("http://www.baidu.com"));
        }

        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            textBox1.Text = e.Result;
        }
    }
}
