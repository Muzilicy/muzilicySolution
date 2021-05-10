using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 线程的Interupt_唤醒_
{
    public partial class Form1 : Form
    {
        private Thread t1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new Thread(() =>
            {
                while (true)
                {
                    MessageBox.Show("111111");
                    try
                    {
                        Thread.Sleep(3000);
                    }
                    catch (ThreadInterruptedException)
                    {
                        MessageBox.Show("谁叫醒了我");
                    }
                }
                
            });
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Interrupt();//线程中断。
        }
    }
}
