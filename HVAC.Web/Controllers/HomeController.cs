using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HVAC.Web.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Blog()
        {
            ViewBag.Message = "Our blog";
            return View();
        }

        public ActionResult BlogDetails()
        {
            ViewBag.Message = "Blog details";
            return View();
        }

        public ActionResult Car()
        {
            ViewBag.Message = "Our cars";
            return View();
        }

        public ActionResult CarDetails()
        {
            ViewBag.Message = "Car details";
            return View();
        }
    }
}