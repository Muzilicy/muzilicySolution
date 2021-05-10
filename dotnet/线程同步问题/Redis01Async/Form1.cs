using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redis01Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (ConnectionMultiplexer conn = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379"))
            {
                IDatabase db = conn.GetDatabase();
                //await db.StringSetAsync("Name","lichangyou");
                //string s = await db.StringGetAsync("Name");
                ////MessageBox.Show(s);
                //string s = await db.StringGetAsync("name");
                //if(s == null)
                //{
                //    MessageBox.Show("s=null");
                //}
                //else
                //{
                //    MessageBox.Show(s);
                //}
                //数组
                //KeyValuePair<RedisKey, RedisValue>[] kvs = new KeyValuePair<RedisKey, RedisValue>[3];
                //kvs[0] = new KeyValuePair<RedisKey, RedisValue>("school", "ecjtu");
                //kvs[1] = new KeyValuePair<RedisKey, RedisValue>("class", "2012");
                //kvs[2] = new KeyValuePair<RedisKey, RedisValue>("major", "software");
                //await db.StringSetAsync(kvs);
                //存储数据结构和取出来使用的数据结构应该保持一致
                await db.ListLengthAsync("school");
            }
            MessageBox.Show("ok");
        }
    }
}
