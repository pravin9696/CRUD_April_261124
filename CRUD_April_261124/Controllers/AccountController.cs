using CRUD_April_261124.Models;
using CRUD_April_261124.Models.validationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_April_261124.Controllers
{
    public class AccountController : Controller
    {
        private CompanyDBEntities dbo = new CompanyDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            List<tbllogin> logins = dbo.tbllogins.ToList();
            return View(logins);
        }
        public ActionResult Home()
        {
            return View();
        }
        //creaet 
        [HttpGet]
        public ActionResult SignUp()
        {        
           
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(loginClass lgc)
        {
            if (ModelState.IsValid)
            {
                tbllogin lg = new tbllogin();
                lg.userID = lgc.userID;
                lg.password = lgc.password;

                dbo.tbllogins.Add(lg);
                int n = dbo.SaveChanges();
                if (n > 0)
                {
                    return RedirectToAction("home");
                }
            }            
            return View();
        }
        [HttpGet]
        public ActionResult updateLogin(int id)
        {
            tbllogin lg = dbo.tbllogins.FirstOrDefault(x => x.Id == id);
            loginClass lgc = new loginClass();
            lgc.Id = lg.Id;
            lgc.userID = lg.userID;
            lgc.password = lg.password;
            return View(lgc);
        }
        [HttpPost]
        public ActionResult updateLogin(loginClass lgc)
        {
            tbllogin lg = dbo.tbllogins.FirstOrDefault(x=>x.userID==lgc.userID);
            if (lg!=null)
            {          
                lg.password = lgc.password;

               int n= dbo.SaveChanges();
                if (n>0)
                {
                    return RedirectToAction("home");
                }
            }
            return View();
        }
        //delete without confirmation
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    //tbllogin lg = dbo.tbllogins.Find(id);
        //    tbllogin lg = dbo.tbllogins.FirstOrDefault(x=>x.Id==id);
        //    if (lg!=null)
        //    {
        //        dbo.tbllogins.Remove(lg);
        //       int n= dbo.SaveChanges();
        //        if (n > 0) 
        //        {
        //            return RedirectToAction("index");
        //        }
        //    }
        //    return View();
        //}
        //delete with confirmation
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tbllogin lg = dbo.tbllogins.Find(id);

            return View(lg);
        }
        [HttpPost]
        public ActionResult Delete(tbllogin lg)
        {
            tbllogin lgtemp = dbo.tbllogins.FirstOrDefault(x => x.Id == lg.Id);
                dbo.tbllogins.Remove(lgtemp);
            int n = dbo.SaveChanges();
            if ((n>0))
            {
                return RedirectToAction("index");
            }
            return View(lg);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            tbllogin lg = dbo.tbllogins.FirstOrDefault(x=>x.Id==id);
            if (lg!=null)
            {
                return View(lg);
            }
            return RedirectToAction("index");
        }
    }
}