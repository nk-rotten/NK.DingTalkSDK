using NK.DingTalk.Api;
using System;
using System.Web.Mvc;

namespace NK.DingTalkWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Attendance.ListSchedule("", DateTime.Now);
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
    }
}