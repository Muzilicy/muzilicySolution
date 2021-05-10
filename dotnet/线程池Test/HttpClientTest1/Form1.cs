using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClientTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync("https://www.keybr.com/");
            textBox1.Text = html;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("userName", "admin"));
            parameters.Add(new KeyValuePair<string, string>("password", "123"));
            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);
            HttpResponseMessage msg = await hc.PostAsync("http://127.0.0.1:8011/Home/Login",content);
            //msg.StatusCode //响应码
            //msg.Content //相应体  异步
            MessageBox.Show($"响应码：{msg.StatusCode}");
            string html = await msg.Content.ReadAsStringAsync();
            MessageBox.Show($"内容：{html}");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            string json = "{userName:'admin',password:'123'}";
            StringContent content = new StringContent(json); //报文头里面放入参数
            //服务器端要求的是json
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            HttpResponseMessage msg= await hc.PostAsync("http://127.0.0.1:8011/Home/Login2", content);
            MessageBox.Show($"响应码：{msg.StatusCode}");
            string html = await msg.Content.ReadAsStringAsync();
            MessageBox.Show($"内容：{html}");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            HttpClient hc = new HttpClient();
            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Headers.Add("UserName", "admin");//报文头添加自定义信息
            content.Headers.Add("Password", "123");
            using(FileStream fs = File.OpenRead("d:/1.txt"))
            {
                content.Add(new StreamContent(fs), "file", "1.txt");//file  表示传文件
                HttpResponseMessage msg = await hc.PostAsync("http://127.0.0.1:8011/Home/Upload", content);
                MessageBox.Show(msg.StatusCode.ToString());
                MessageBox.Show(await msg.Content.ReadAsStringAsync());
            }
        }
    }
}
