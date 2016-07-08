using System.Web.Mvc;
using BasicCMSPage.Infrastructure;
using BasicCMSPage.Interfaces;
using Repositories.ViewModels;

namespace BasicCMSPage.Controllers
{
    /// <summary>
    /// Account controller
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        #region Constructor

        /// <summary>
        /// Authentication class
        /// </summary>
        private IAuthentication authentication;

        /// <summary>
        /// Constructor method
        /// </summary>
        public AccountController()
        {
            this.authentication = new FormsAuth();
        }

        #endregion

        #region Action methods
        /// <summary>
        /// Login page
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LogInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authentication.Authenticate(model.Name, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
            }
            ModelState.AddModelError("", "Złe hasło lub nazwa użytkownika");
            return View();
        }

        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Logout()
        {
            authentication.LogOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}