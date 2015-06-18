using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.BuyNet;






namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Service1Client client = new Service1Client();
          
         return View(client.GetProducts().ToList());
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