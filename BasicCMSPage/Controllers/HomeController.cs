using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Repositories.IRepository;

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
            IEnumerable<News> news = repository.GetAllNews();
            return View(news);
        }

        /// <summary>
        /// Show add news page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }

        /// <summary>
        /// Add news to db
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(News news)
        {
            if (ModelState.IsValid)
            {
                repository.AddNews(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        /// <summary>
        /// Edit method, show edit form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(long id)
        {
            News news = repository.GetNews(id);
            return View(news);
        }

        /// <summary>
        /// Edit method to update news in db
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateNews(news);
                return RedirectToAction("Index");
            }
            return View("Edit",news);
        }

        #endregion

    }
}
