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
       public static Service1Client client = new Service1Client();
        public ActionResult Index()
        {

       
       
            return View(client.GetProducts());
        }
        public ActionResult Add()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(bool Condition,string Description,string Name,decimal Price,
            string SubCategories_Categories_Name, string SubCategories)
        {

            Service1Client client = new Service1Client();
            Product product = new Product() { Condition = Condition, Description = Description, Name = Name, Price = Price,
                SubCategories = client.SubCategories().FirstOrDefault(sub=>sub.Name==SubCategories),
             
            };
            client.AddProduct(product);
            
            return View("index", client.GetProducts());
        }
        public ActionResult Remove(int id)
        {
            Service1Client client = new Service1Client();
          Product pro=  client.GetProduct(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult RemoveProduct(int id)
        {

            Service1Client client = new Service1Client();
            client.Delete_Product(id);
            return View("index", client.GetProducts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(byte[] img)
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserP()
        {
            ViewBag.Message = "Your contact page.";

            return View(client.GetUser(1));
        }
    }
}