using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.BuyNet;
using System.Net;
using System.Web.Security;



namespace MvcProject.Controllers
{
    public class UserController : Controller
    {
        //private UserContext db = new UserContext();
        public static Service1Client db = new Service1Client();

        // GET: /User/
        public ActionResult Index()
        {
            return View(db.Users());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

             User user = db.GetUser((int)id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View (user);
            
           
            
        }

        // GET: /User/Login
        public ActionResult Login()
        {
            return PartialView();
        }
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }
      
        //
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            ViewData["Logoff"] = true;

            return PartialView("Index");
        }
        //
      
        //Login post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
         
                //var v = fe.User.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password));
                  var v =db.GetUser(user.Id);
                    if (v != null)
                    {
                        Session["LogUserId"] = user.Id.ToString();
                        Session["LogUserName"] = user.UserName.ToString();
                         //Session["User"] = user;
                    }
                    return RedirectToAction("AfterLogin");
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogUserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,Country,Email,First_Name,Last_Name,Notes,Password,Street_number,UserName,Zip_Code")]  BuyNet.User user)
        {

            if (ModelState.IsValid)
            {
                db.AddUser(user);
               
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyNet.User user = db.GetUser((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,Country,Email,First_Name,Last_Name,Notes,Password,Street_number,UserName,Zip_Code")] BuyNet.User user)
        {
            if (ModelState.IsValid)
            {
                db.Edit_User(user.Id,user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyNet.User user = db.GetUser((int)id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete_User(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.dbDispose();
            }
            base.Dispose(disposing);
        }
    }
}
    
