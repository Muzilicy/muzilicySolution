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

namespace TPL中的异常
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            try
            {
                Task<string> task1 = hc.GetStringAsync("http://1111aaaaa.com");
                Task<string> task2 = hc.GetStringAsync("http://1111111aaaaa.com");
                Task<string> task3 = hc.GetStringAsync("http://1111111111111aaaaa.com");
                Task.WaitAll(task1, task2, task3);//发生一个或多个错误。”
                MessageBox.Show("下载成功");
            }
            catch (AggregateException ae)
            {
                //发生一个或者多个错误
                //遍历所有的异常
                foreach (Exception ex in ae.InnerExceptions)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
    }
}
