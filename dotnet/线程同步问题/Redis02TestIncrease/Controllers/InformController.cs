using Redis02TestIncrease.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Redis02TestIncrease.Controllers
{
    public class InformController : Controller
    {
        private readonly string Inform_Prefix = "muzilicy_Inform_";

        // GET: Inform
        public async Task<ActionResult> Index(int id)
        {
            using(ConnectionMultiplexer conn = await ConnectionMultiplexer.ConnectAsync("127.0.0.1:6379"))
            {
                //默认是访问db0数据库,可以通过方法参数指定数字访问不同的数据库
                IDatabase db = conn.GetDatabase();
                //以ip和新闻的id为key
                string hasClickKey = Inform_Prefix + Request.UserHostAddress + "_" + id;
                //如果之前这个ip给这篇文章贡献过点击量，则不重复计算点击量
                if(db.KeyExists(hasClickKey) == false)
                {
                    await db.StringIncrementAsync(Inform_Prefix  + id, 1);
                    //记录一下这个ip给这篇文章共享的点击量，有效期为1天
                    db.StringSet(hasClickKey, "a", TimeSpan.FromDays(1));
                }
                RedisValue clickCount = await db.StringGetAsync(Inform_Prefix + id);
                InformModel model = new InformModel();
                model.ClickCount = Convert.ToInt32(clickCount);
                return View(model);
            }
            
        }
    }
}