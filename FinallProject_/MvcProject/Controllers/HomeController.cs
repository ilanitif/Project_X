using MvcProject.BuyNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;








namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
      public static Service1Client client = new Service1Client();
        public ActionResult Top3products()
        {



            return View(client.GetProducts());
        }
        public  ActionResult Index()
        {
            return View();
        } 

        public ActionResult Add()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(bool Condition, string Description, string Name, decimal Price,
            string SubCategories_Categories_Name, string SubCategories, string image)
        {

            Service1Client client = new Service1Client();
            Guid g = Guid.NewGuid();
            Images ima = new Images()
            {
                User = (User)Session["User"],
                img = "~/pics/" + g,
                UserId = int.Parse((string)Session["LogUserId"])

            };
            client.AddImage(ima);
            Product product = new Product()
            {
                Condition = Condition,
                Description = Description,
                Name = Name,
                Price = Price,
            };
            client.AddProduct(product);

            return View("index", client.GetCategories());
        }
        public ActionResult Remove(int id)
        {
            Service1Client client = new Service1Client();
            Product pro = client.GetProduct(id);
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
        public ActionResult Aboutas()
        {
            //byte[] img

            ViewBag.Message = "Your application description page.";

            return View(client.GetProducts());
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
        public ActionResult Product_Page(int id)
        {


            return View(client.GetProduct(id));
        }

        public ActionResult SellNewProduct()
        {
            return View();
        }
        public ActionResult SearchActionMethod(string word)
        {
            List<string> words = new List<string>();
            foreach (var item in client.GetProducts())
            {
                if (item.Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Name);
                    //words.Add(item.User.UserName);
                }
            }
            foreach (var item in client.GetShipping_Companys())
            {
                if (item.Company_Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Company_Name);
                }
            }
            foreach (var item in client.SubCategories())
            {
                if (item.Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Name);
                }
            }
            foreach (var item in client.GetProducts())
            {
                if (item.Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Name);
                }
            }
            foreach (var item in client.GetCategories())
            {
                if (item.Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Name);
                }
                   
            }
            client.GetCategories();
          
          
            return Json(words.Take(5), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Category(int categoryId)
        {
            
            return View(client.GetCategory(categoryId));
        }


    }
}