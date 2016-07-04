using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(NewsAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                News news = Mapper.Map<NewsAddViewModel, News>(model);
                repository.AddNews(news);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Edit method, show edit form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(long id)
        {
            NewsEditViewModel news = Mapper.Map<NewsEditViewModel>(repository.Get(id));
            return View(news);
        }

        /// <summary>
        /// Edit method to update news in db
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(NewsEditViewModel edit)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateNews(edit);
                return RedirectToAction("Index");
            }
            return View("Edit", edit);
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

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long id)
        {
            //repository.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// List of news to management
        /// </summary>
        /// <returns></returns>
        //public ActionResult List()
        //{
        //    IEnumerable<News> news = repository.GetAll();
        //    return View(news);
        //}
        #endregion

    }
}
