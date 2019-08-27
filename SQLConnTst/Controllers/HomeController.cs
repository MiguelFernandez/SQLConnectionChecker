using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQLConnTst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sql = new SQL();
            // sql.ConnectToSQL();
                      
            
            return View(sql);
        }
        [HttpPost]
        public ActionResult Index(SQL sql)
        {           
            sql.ConnectToSQL();
           
            return View(sql);
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