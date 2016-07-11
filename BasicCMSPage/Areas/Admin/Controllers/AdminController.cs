using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Domain;
using Repositories.IRepository;
using Repositories.ViewModels;

namespace BasicCMSPage.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        #region constructor
        /// <summary>
        /// News repository
        /// </summary>
        private IAdminRepository repository;

        /// <summary>
        /// Constructor fro AdminController
        /// </summary>
        /// <param name="repository"></param>
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        /// <summary>
        /// Index method, redirect to List()
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// List of news
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            List<News> list = repository.GetAll().ToList();
            List<NewsAdminListViewModel> news = Mapper.Map<List<NewsAdminListViewModel>>(list);
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(NewsAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                News news = Mapper.Map<NewsAddViewModel, News>(model);
                repository.AddNews(news);
                return RedirectToAction("List");
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
                return RedirectToAction("List");
            }
            return View("Edit", edit);
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long id)
        {
            repository.Delete(id);
            return RedirectToAction("List");
        }
    }
}