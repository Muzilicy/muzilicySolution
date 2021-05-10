using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace 线程的join
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(() => {
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("t1 " + i);
            //    }
            //});
            //t1.Start();
            //Thread t2 = new Thread(() => {
            //    t1.Join();//等着 t1 执行结束
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("t2 " + i);
            //    }
            //});
            //t2.Start();
            //Console.ReadKey();

            //IList<Person> persons = GetEmpList();
            //业务类型不匹配的问题   Form  和  Grid问题
            
            JObject json = new JObject();
            //无自定义界面的时候
            //string path = $"D:/test/ProjectDocumentList.js";
            string path = $"D:/test/ProjectDocumentEdit.js";
            FileStream fs = new FileStream(path,FileMode.Open,FileAccess.Read);
            DataTable dt = new DataTable();
            dt.Columns.Add("header",typeof(string));
            dt.Columns.Add("dataIndex", typeof(string));
            dt.Columns.Add("hidden", typeof(Boolean));
            try
            {
                int jsSize = (int)fs.Length;
                byte[] bt = new byte[jsSize];
                fs.Read(bt, 0, jsSize);
                //存在自定义界面的时候
                string jsonStr = Encoding.UTF8.GetString(bt);
                //无自定义界面的时候
                //string jsonStr = Encoding.UTF8.GetString(bt)
                    //.Replace("var individualConfigInfo =", " ").Replace("\r\n", " ").Replace(" ","");
                //jsonStr = "{" + jsonStr.Remove(0, 2);
                json = JObject.Parse(jsonStr);
                JArray jColumn = JArray.Parse(json["grid"]["wm3_doc_docgrid"]["columns"].ToString());
                for (int i = 0; i < jColumn.Count; i++)
                {
                    JObject jo = JObject.Parse(jColumn[i].ToString());
                    DataRow row = dt.NewRow();
                    row["header"] = jo["header"].ToString();
                    row["dataIndex"] = jo["dataIndex"].ToString();
                    row["hidden"] = jo["hidden"].ToString() == "true";
                    dt.Rows.Add(row);
                }
            }
            finally
            {
                fs.Close();
            }
            
            
            Console.ReadKey();

        }

        public static IList<Person> GetEmpList()
        {
            IList<Person> personlist = new List<Person>();
            IList<Emp> emplist = new List<Emp>();
            emplist.Add(new Emp()
            {
                Age = 27,
                Name = "lcy",
                Salary = 3333333333333
            });
            personlist.Add(emplist[0]);
            return personlist;
        }
    }



    class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }
    }

    class Emp : Person
    {
        public Decimal Salary { get; set; }
    }
}
