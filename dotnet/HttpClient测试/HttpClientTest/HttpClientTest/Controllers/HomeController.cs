using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HttpClientTest.Controllers
{
    public class HomeController : Controller
    {
        #region View
        public ActionResult Index()
        {
            return View();
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
        #endregion

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "123")
            {
                return Json("ok");
            }
            else
            {
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult Login2(Login2Request data)
        {
            //dynamic data = JsonConvert.DeserializeObject<dynamic>(content);
            string userName = data.userName;
            string password = data.password;
            if (userName == "admin" && password == "123")
            {
                return Json(data);
            }
            else
            {
                return Json(data);
            }
        }

        public ActionResult Upload(HttpPostedFileBase file1)//替代.net 4.5 中 HttpPostedFileBase
        {
            string userName = Request.Headers["UserName"];//报文头
            string password = Request.Headers["Password"];
            if (userName == "admin" && password == "123")
            {
                var filePath = Server.MapPath("~/Upload" + file1.FileName);
                file1.SaveAs(filePath);
                return Json("ok");
            }
            else
            {
                return Json("error");
            }
        }
    }

    public class Login2Request
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}