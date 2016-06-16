using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicCMSPage.ViewModels;
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
            //IEnumerable<News> news = repository.GetAllNotArchived();
            List<NewsIndexViewModel> news = new List<NewsIndexViewModel>()
            {
                new NewsIndexViewModel() {AddDateTime = DateTime.Now,CommentsCount = 5,News = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed mattis dui. Suspendisse potenti. Donec at enim nec odio mollis venenatis sit amet aliquet leo. Nam eu eros vel nibh ultrices faucibus sed at nunc. Praesent vel mi molestie, lacinia nisl id, dictum tortor. Fusce ullamcorper sodales dui, sed viverra ipsum. Nunc aliquet vel libero scelerisque ornare. Nulla quis congue neque. Vestibulum tincidunt magna at lobortis ultricies. Sed vehicula gravida eros sed tempor. Duis sed tempor sapien. ", User = "Autor Ja", Title = "Tytuł", Views = 10},
                new NewsIndexViewModel() {AddDateTime = DateTime.Now,CommentsCount = 5,News = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed mattis dui. Suspendisse potenti. Donec at enim nec odio mollis venenatis sit amet aliquet leo. Nam eu eros vel nibh ultrices faucibus sed at nunc. Praesent vel mi molestie, lacinia nisl id, dictum tortor. Fusce ullamcorper sodales dui, sed viverra ipsum. Nunc aliquet vel libero scelerisque ornare. Nulla quis congue neque. Vestibulum tincidunt magna at lobortis ultricies. Sed vehicula gravida eros sed tempor. Duis sed tempor sapien. ", User = "Autor Ja", Title = "Tytuł", Views = 10},
                new NewsIndexViewModel() {AddDateTime = DateTime.Now,CommentsCount = 5,News = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed mattis dui. Suspendisse potenti. Donec at enim nec odio mollis venenatis sit amet aliquet leo. Nam eu eros vel nibh ultrices faucibus sed at nunc. Praesent vel mi molestie, lacinia nisl id, dictum tortor. Fusce ullamcorper sodales dui, sed viverra ipsum. Nunc aliquet vel libero scelerisque ornare. Nulla quis congue neque. Vestibulum tincidunt magna at lobortis ultricies. Sed vehicula gravida eros sed tempor. Duis sed tempor sapien. ", User = "Autor Ja", Title = "Tytuł", Views = 10},
                new NewsIndexViewModel() {AddDateTime = DateTime.Now,CommentsCount = 5,News = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed mattis dui. Suspendisse potenti. Donec at enim nec odio mollis venenatis sit amet aliquet leo. Nam eu eros vel nibh ultrices faucibus sed at nunc. Praesent vel mi molestie, lacinia nisl id, dictum tortor. Fusce ullamcorper sodales dui, sed viverra ipsum. Nunc aliquet vel libero scelerisque ornare. Nulla quis congue neque. Vestibulum tincidunt magna at lobortis ultricies. Sed vehicula gravida eros sed tempor. Duis sed tempor sapien. ", User = "Autor Ja", Title = "Tytuł", Views = 10},
                new NewsIndexViewModel() {AddDateTime = DateTime.Now,CommentsCount = 5,News = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc sed mattis dui. Suspendisse potenti. Donec at enim nec odio mollis venenatis sit amet aliquet leo. Nam eu eros vel nibh ultrices faucibus sed at nunc. Praesent vel mi molestie, lacinia nisl id, dictum tortor. Fusce ullamcorper sodales dui, sed viverra ipsum. Nunc aliquet vel libero scelerisque ornare. Nulla quis congue neque. Vestibulum tincidunt magna at lobortis ultricies. Sed vehicula gravida eros sed tempor. Duis sed tempor sapien. ", User = "Autor Ja", Title = "Tytuł", Views = 10}
            };
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
            News news = repository.Get(id);
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
            return View("Edit", news);
        }

        /// <summary>
        /// Method to show details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long id)
        {
            var news = repository.Get(id);
            return View("Details", news);
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(long id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// List of news to management
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            IEnumerable<News> news = repository.GetAll();
            return View(news);
        }
        #endregion

    }
}
