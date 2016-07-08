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
        private INewsRepository repository;

        /// <summary>
        /// Constructor fro AdminController
        /// </summary>
        /// <param name="repository"></param>
        public AdminController(INewsRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        public ActionResult List()
        {
            return View();
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
    }
}