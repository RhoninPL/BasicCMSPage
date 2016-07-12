using BasicCMSPage.Interfaces;
using Domain;
using System.Linq;
using System.Web.Security;

namespace BasicCMSPage.Infrastructure
{
    /// <summary>
    /// Forms authentication class
    /// </summary>
    public class FormsAuth : IAuthentication
    {
        /// <summary>
        /// DB context
        /// </summary>
        private readonly DBContainer _context = new DBContainer();

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string userName, string password)
        {
            var result = _context.Users.FirstOrDefault(u => u.Name == userName && u.Password == password);
            if (result == null)
            {
                return false;
            }
            else
            {
                FormsAuthentication.SetAuthCookie(userName, true);
                return true;
            }
        }

        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns></returns>
        public bool LogOut()
        {
            FormsAuthentication.SignOut();
            return true;
        }
    }
}