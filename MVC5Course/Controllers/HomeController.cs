using MVC5Course.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            return View("LoginResult",data);
        }

        public ActionResult Index()
        {
            logger.Trace("我是Trace");
            logger.Debug("我是Debug");
            logger.Info("我是Info");
            logger.Warn("我是Warn");
            logger.Error("我是Error");
            logger.Fatal("我是Fatal");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            try
            {
                int a = 6;
                int b = 0;
                int result = a / b;
            }
            catch (Exception ex)
            {
                logger.Fatal(LogUtility.BuildExceptionMessage(ex));
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}