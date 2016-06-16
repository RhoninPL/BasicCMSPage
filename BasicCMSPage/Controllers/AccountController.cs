//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using BasicCMSPage.Infrastructure;
//using BasicCMSPage.ViewModels;
//using Domain;

//namespace BasicCMSPage.Controllers
//{
//    public class AccountController : Controller
//    {

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult LogIn()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult LogIn(LogInViewModel user)
//        {
//            if (!ModelState.IsValid)
//            {
//                return RedirectToAction("LogIn");
//            }
//            OwinAuthHelper auth = new OwinAuthHelper();
//            auth.LogIn(user);
//            return RedirectToAction("Index", "Home");
//        }

//        public ActionResult LogOut()
//        {
//            return View();
//        }
//    }
//}