using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ManualResetEventTest
{
    class Program
    {
        static void Main(string[] args)
        {

            #region origin
            //string[] s = "".Split('_');
            //string filePath = "1.txt";

            //string[] fileExtensions = filePath.Split('.');
            //string fileExtension = fileExtensions[fileExtensions.Length - 1];

            //string str = "获取文件的全路径：" + Path.GetFullPath(filePath); //-->C:1.txt

            //str = "获取文件所在的目录：" + Path.GetDirectoryName(filePath); //-->C:

            //Console.WriteLine(str);

            //str = "获取文件的名称含有后缀：" + Path.GetFileName(filePath); //-->1.txt

            //str = "获取文件的名称没有后缀：" + Path.GetFileNameWithoutExtension(filePath); //-->1

            //str = "获取路径的后缀扩展名称：" + Path.GetExtension(filePath); //-->.txt

            //str = "获取路径的根目录：" + Path.GetPathRoot(filePath); //-->C:\

            //ManualResetEvent mre = new ManualResetEvent(false);
            //Thread t1 = new Thread(() =>
            //{
            //    //while (true)
            //    //{
            //    Console.WriteLine("等着开门");
            //    mre.WaitOne(); //初始状态
            //    Console.WriteLine("终于等到开门");
            //    //}

            //});
            //t1.Start();
            //Console.WriteLine("按任意键开门");
            //Console.ReadKey();
            //mre.Set();
            //Console.ReadKey(); 
            #endregion


            //JObject jObject = JObject.Parse("{\"error\":[],\"result\":{\"XXBTZUSD\":{\"asks\":[[\"7510.10000\",\"0.737\",1510970501]],\"bids\":[[\"7503.70000\",\"0.004\",1510970508]]}}} ");
            //Rootobject root = JsonConvert.DeserializeObject<Rootobject>("{\"error\":[],\"result\":{\"XXBTZUSD\":{\"asks\":[[\"7510.10000\",\"0.737\",1510970501],[\"75111.10000\",\"0.7371\",15109705011]],\"bids\":[[\"7503.70000\",\"0.004\",1510970508]]}}} ");
            //var resposeData = "[[1400025600, 9633460, 9667535, 2698.09, 2734.73, 2749, 2698.08, 25333.3057, 11784.9, 13548.4, 69148900],[1400112000,9667536,9700700,2734.94,2771.01,2790,2731.48,24260.1011,11824.5,12435.6,67093300],[1400198400,9700701,9736706,2771,2789,2816.33,2730,34824.2351,17912.2,16912,96751200],[1400284800,9736707,9752556,2789,2782.03,2800,2775,9279.0273,4603.73,4675.29,25840300]]";
            //JArray jsonObj = (JArray)JsonConvert.DeserializeObject(resposeData);

            //JsonConvertHelper();
            DateTime? dt = null;
            dt ??= DateTime.Now;
            DateTime dt2 = DateTime.Parse("2006-04-30 11:11");
            DateTime dt1 = DateTime.Parse("2006-06-05 12:11");
            DateTime dt3 = DateTime.Now.Date;
            //int split = DateTime.Compare(dt1, dt2);
            //if (split > 0)
            //{
                int Month = (dt2.Year - dt1.Year) * 12 + (dt2.Month - dt1.Month);
            //}
            Console.ReadLine();
        }
        //Json对象的返回需要按照实际情况处理，转换
        //JsonConvert.DeserialObject<T>(json);
        private static void JsonConvertHelper()
        {
            //string json = @"{\"FormDefinition\": [{\"$id\":\"4\",\"Class\":558,\"ClassDisplayLabel\":\"Punchworks\",\"Name\":\"Punchworks Form\"},{\"$id\":\"91\",\"Class\":558,\"ClassDisplayLabel\":\"Punchworks\",\"Name\":\"Test_something4\"}]}";
            string json = "{\"FormDefinition\": [{\"$id\":\"4\",\"Class\":558,\"ClassDisplayLabel\":\"Punchworks\",\"Name\":\"Punchworks Form\"},{\"$id\":\"91\",\"Class\":558,\"ClassDisplayLabel\":\"Punchworks\",\"Name\":\"Test_something4\"}]}";
            //FormDefinitionList formDefinitionList = JsonConvert.DeserializeObject<FormDefinitionList>(json);
            FormDefinitionList formDefinitionList = Deserialize<FormDefinitionList>(json);
            IList<FormDefinition> FormDefinitions = formDefinitionList.FormDefinitions;
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json.Replace("\"$id\"", "\"id\""));
        }
        public class FormDefinitionList
        {
            [JsonProperty("FormDefinition")]
            public List<FormDefinition> FormDefinitions { get; set; }
        }

        public class FormDefinition
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("Class")]
            public int Class { get; set; }

            [JsonProperty("ClassName")]
            public string ClassName { get; set; }

            [JsonProperty("ClassDisplayLabel")]
            public string ClassDisplayLabel { get; set; }

            [JsonProperty("Definition")]
            public string Definition { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }
        }
        public class Rootobject
        {
            public object[] error { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public XXBTZUSD XXBTZUSD { get; set; }
        }

        public class XXBTZUSD
        {
            public object[][] asks { get; set; }
            public object[][] bids { get; set; }
        }

    }
}
