using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using TestIService;
using TestService;
using 异步的增删改查.Models;

namespace 异步的增删改查.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public async Task<ActionResult> Index()
        {
            IPeronService ps = new PersonService();
            var persons = await ps.GetAllAsync();
            return View(persons);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNew(PersonAddNewModel model)
        {
            IPeronService ps = new PersonService();
            await ps.AddAsync(model.Name, model.Age);
            return Redirect("/Person/Index");
        }

        [HttpGet]
        public async Task<ActionResult> Export()
        {
            IPeronService ps = new PersonService();
            var persons = await ps.GetAllAsync();
            this.Response.AddHeader("Content-Disposition", "attachment; " +
                "filename=2.txt");
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms);
            //using (MemoryStream ms = new MemoryStream())
            //using (StreamWriter writer = new StreamWriter(ms))
            //{
            //    foreach (var person in persons)
            //    {
            //        await writer.WriteLineAsync($"{person.Name}:{person.Age}");
            //    }
            //    //writer.Flush();//写入
            //    //ms.Position = 0;//回到原位
            //    //return File(ms, "text/plain");
            //}
            foreach (var person in persons)
            {
                await writer.WriteLineAsync($"{person.Name}:{person.Age}");
            }
            writer.Flush();//写入
            ms.Position = 0;//回到原位
            return File(ms, "text/plain");
        }
    }
}