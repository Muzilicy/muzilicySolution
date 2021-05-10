using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPL风格Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FileStream fs = File.OpenRead("d:/1.txt"))
            {
                byte[] buffer = new byte[50];
                Task<int> task = fs.ReadAsync(buffer,0,buffer.Length);
                task.Wait();//耗时操作
                string s = Encoding.UTF8.GetString(buffer);
                textBox1.Text = s;
            }

        }

        //TPL风格
        private async void button2_Click(object sender, EventArgs e)
        {
            using(FileStream fs = File.OpenRead("d:/1.txt"))
            {
                byte[] buffer = new byte[50];
                //await的意思就是等待ReadAsync执行结束
                //await只能用到异步方法中
                await fs.ReadAsync(buffer, 0, buffer.Length);
                string s = Encoding.UTF8.GetString(buffer);
                textBox1.Text = s;
            }
        }
    }
}
