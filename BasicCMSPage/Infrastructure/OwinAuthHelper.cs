//using Domain;
//using Repositories.Repository;
//using System.Web;
//using System;
//using System.Collections.Generic;
//using System.Web.Security;
//using Microsoft.AspNet.Identity;
//using System.Security.Claims;
//using BasicCMSPage.ViewModels;

//namespace BasicCMSPage.Infrastructure
//{
//    public class OwinAuthHelper
//    {
//        private UsersRepository repository;

//        public OwinAuthHelper()
//        {
//            repository = new UsersRepository();
//        }

//        public bool LogIn(LogInViewModel users)
//        {
//            var user = repository.FindByName(users.Name);
//            if (user == null)
//            {
//                return false;
//            }

//            var context = HttpContext.Current.GetOwinContext();
//            var authenticationManager = context.Authentication;

//            var claims = new List<Claim>();
//            claims.Add(new Claim(ClaimTypes.Name,user.Name));
//            claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()));

//            var identity = new ClaimsIdentity(claims,DefaultAuthenticationTypes.ApplicationCookie);
//            authenticationManager.SignIn(identity);

//            return true;
//        }

//        public void LogOut()
//        {
//            var context = HttpContext.Current.GetOwinContext();
//            var authenticationManager = context.Authentication;
//            authenticationManager.SignOut();
//        }
//    }
//}