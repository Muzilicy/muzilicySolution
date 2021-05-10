using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPL探秘1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string i1 = await F1Async();
            MessageBox.Show("i1=" + i1);
            string i2 = await F2Async();
            MessageBox.Show("i2=" + i2);
        }

        static Task<string> F1Async()
        {
            MessageBox.Show("F1 start");
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                MessageBox.Show("F1 Run");
                return "F1";
            });
        }


        static Task<string> F2Async()
        {
            MessageBox.Show("F2 start");
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                MessageBox.Show("F2 Run");
                return "F2";
            });
        }

        /// <summary>
        /// 分析
        /// 并不是到了await才开始执行Task异步任务，而是这里是一个“最终保障”
        /// 尽量直接await
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            //状态机
            Task<string> task1 = F1Async();
            Task<string> task2 = F2Async();
            string i1 = await task1; //task1到这 一定执行完成
            //并不是到了await才开始执行Task异步任务，而是这里是一个“最终保障”
            MessageBox.Show("i1=" + i1);
            string i2 = await task2;
            MessageBox.Show("i2=" + i2);
        }
    }
}
