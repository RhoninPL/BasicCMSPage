using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Repositories.IRepository;
using Repositories.ViewModels;

namespace BasicCMSPage.Controllers
{
    /// <summary>
    /// Controller for Home
    /// </summary>
    public class HomeController : Controller
    {
        #region Constructor

        /// <summary>
        /// News repository
        /// </summary>
        private INewsRepository repository;

        /// <summary>
        /// Constructor fro HomeController
        /// </summary>
        /// <param name="repository"></param>
        public HomeController(INewsRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Index method, showing all news
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<News> news = repository.GetAllNotArchived().ToList();
            List<NewsIndexViewModel> newsList = Mapper.Map<List<NewsIndexViewModel>>(news);
            return View(newsList);
        }
        
        /// <summary>
        /// Method to show details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long id)
        {
            var news = repository.Get(id);
            NewsDetailsViewModel newsDetails = Mapper.Map<NewsDetailsViewModel>(news);
            return View("Details", newsDetails);
        }

        #endregion

    }
}
