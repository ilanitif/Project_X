using MvcProject.BuyNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;








namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        public static Service1Client db = new Service1Client();
        public static Service1Client client = new Service1Client();
        public ActionResult Top3products()

        {
            Dictionary<Product, Category> all = new Dictionary<Product, Category>();
            foreach (var item in client.GetCategories())
            {
                List<Product> pro = new List<Product>();
                foreach (var p in client.GetProducts())
                {

                    
                    if (p.Category.ParentCategory.Id==item.Id)
                    {
                        pro.Add(p);
                    }
                    else if (p.Category.ParentCategory.ParentCategory!=null && p.Category.ParentCategory.ParentCategory.Id == item.Id)
                    {
                        pro.Add(p);
                    }

                }
                pro.OrderByDescending(pr => pr.Rate).Take(3);
                foreach (var i in pro)
                {
                    all.Add(i, item);
                }

            }


            return PartialView(all);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {


            var v = db.GetUser(user.Id);
            if (v != null)
                {
                    Session["LogUserId"] = user.Id.ToString();
                    Session["LogUserName"] = user.UserName.ToString();

                }
                return RedirectToAction("AfterLogin");
         

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


        public ActionResult SearchActionMethod(string word)
        {
            List<string> words = new List<string>();
            foreach (var item in client.GetProducts())
            {
                if (item.Name.ToUpper().Contains(word.ToUpper()) && word != String.Empty)
                {
                    words.Add(item.Name);
                   
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
        public ActionResult Category(string category)
        {
            Category ca = client.GetCategories().FirstOrDefault(c => c.Name == category);
            return View(ca);
        }
        public ActionResult SubCategory(string subcategory)
        {
            Category sub = client.SubCategories().FirstOrDefault(c => c.Name == subcategory);
            Dictionary<Product,Category> prosub = client.GetProducts().Where(p => p.CategoryId == sub.Id).ToDictionary(p=>p,p=> p.Category);
            return View(prosub);
        }

        public ActionResult ContactUs()
        {

            return View();
        }

        public ActionResult YourDeatails()
        {


            return View();
        }
        public ActionResult NavigationBar()
        {


            return View();
        }
        public ActionResult SellNewProduct()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SellNewProduct(string productName, int? categoryId, int? subCategoryId, bool? itemCondiation, decimal? price,
            string productDescription, HttpPostedFileBase [] files)
        {
              //< httpRuntime targetFramework = "4.5.2" />
             Product p = new Product()
            {
                CategoryId = subCategoryId,
                Condition = itemCondiation ?? true,
                Price = price,
                Description = productDescription,
                Category = client.SubCategory(subCategoryId ?? 1)
            };
            client.AddProduct(p);
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                //foreach (var item in Request.Files)
                //{
                //    if (item != null && item.ContentLength > 0)
                //    {
                //        var fileName = Path.GetFileName(file.FileName);
                //        var path = Path.Combine(Server.MapPath("~/pics/"), fileName);
                //        file.SaveAs(path);
                //    }
                //}
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/pics/"), fileName);
                    file.SaveAs(path);
                }
            }
           

            foreach (var photovar in Request.Files)
            {
                if (photovar is HttpPostedFileBase)
                {
                    HttpPostedFileBase photo = (HttpPostedFileBase)photovar;

                    if (photo != null && photo.ContentLength > 0)
                    {
                        Guid g = Guid.NewGuid();
                        string directory = @"~/pics/" + g;

                        Images ima = new Images()
                        {
                            img = directory,
                            ProductId = client.GetProducts().FirstOrDefault(pr => pr == p).Id
                        };


                        if (photo.ContentLength > 10240)
                        {
                            ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
                            return View();
                        }

                        var supportedTypes = new[] { "jpg", "jpeg", "png" };

                        var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                        if (!supportedTypes.Contains(fileExt))
                        {
                            ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                            return View();
                        }

                        var fileName = Path.GetFileName(photo.FileName);
                        photo.SaveAs(Path.Combine(directory, fileName));
                    }

                }
            }

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
        //    [HttpPost]
        //    //public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        //    //{
        //    //    if (photo != null && photo.ContentLength > 0)
        //    //    {
        //    //        string directory = @"D:\Temp\";

        //    //        if (photo.ContentLength > 10240)
        //    //        {
        //    //            ModelState.AddModelError("photo", "The size of the file should not exceed 10 KB");
        //    //            return View();
        //    //        }

        //    //        var supportedTypes = new[] { "jpg", "jpeg", "png" };

        //    //        var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

        //    //        if (!supportedTypes.Contains(fileExt))
        //    //        {
        //    //            ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //    //            return View();
        //    //        }

        //    //        var fileName = Path.GetFileName(photo.FileName);
        //    //        photo.SaveAs(Path.Combine(directory, fileName));
        //    //    }

        //    //    foreach (var file in files)
        //    //    {
        //    //        file.SaveAs(...);
        //    //    }

        //    //    return RedirectToAction("Index");
        //    //}
        //    //[HttpPost]
        //    //public ActionResult Upload(HttpPostedFileBase photo)
        //    //{
        //    //    string directory = @"D:\Temp\";

        //    //    if (photo != null && photo.ContentLength > 0)
        //    //    {
        //    //        var fileName = Path.GetFileName(photo.FileName);
        //    //        photo.SaveAs(Path.Combine(directory, fileName));
        //    //    }

        //    //    return RedirectToAction("Index");
      
    }
}