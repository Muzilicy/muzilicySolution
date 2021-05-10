using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1_1.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //异步  提升性能  提升服务器的吞吐量：可以处理并发请求数
        //能用异步  就不要用同步   可以大大提升系统的吞吐量
        //异步具有传染性   await  async出现   涉及到的都出现
        public async Task<ActionResult> Index()
        {
            using (FileStream stream = System.IO.File.OpenRead("d:/1.txt"))
            using (StreamReader sr = new StreamReader(stream))
            {
                string txt = await sr.ReadToEndAsync();
                return Content(txt);
            }
            //return View();
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}