using HttpClientTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace HttpClientTest.Controllers
{
    public class HomeController : Controller
    {
        #region 原始
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [System.Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        [System.Obsolete]
        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
        #endregion

        [HttpPost]
        public ActionResult Login(string userName,string password)
        {
            if(userName == "admin" && password == "123")
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
            if(userName == "admin" && password == "123")
            {
                return Json(data);
            }
            else
            {
                return Json(data);
            }
        }

        public ActionResult Upload(IFormFile file)//替代.net 4.5 中 HttpPostedFileBase
        {
            string userName = Request.Headers["UserName"];
            string password = Request.Headers["Password"];
            string webRootPath = hostingEnvironment.WebRootPath;
            string contentRootPath = hostingEnvironment.ContentRootPath;
            if (userName == "admin" && password == "123")
            {
                var filePath = webRootPath + @"/Upload"+file.FileName;
                using(FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }
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
