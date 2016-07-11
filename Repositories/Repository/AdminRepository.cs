using System;
using System.Collections.Generic;
using System.Data.Entity;
using Domain;
using Repositories.IRepository;
using Repositories.Repository.BaseRepository;
using Repositories.ViewModels;

namespace Repositories.Repository
{
    public class AdminRepository : BaseRepository<News>, IAdminRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AdminRepository() : base()
        {}

        #endregion
        

        /// <summary>
        /// Add news to the DB
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News news)
        {
            news.AddDate = DateTime.Now;
            news.ModificationDate = DateTime.Now;
            news.Description = news.Content.Substring(0, news.Content.Length > 252 ? 252 : news.Content.Length) + "...";
            news.UsersId = 1; // TODO: change 1 to id of user
            dbSet.Add(news);
            context.SaveChanges();
        }

        /// <summary>
        /// Update news in DB
        /// </summary>
        /// <param name="news"></param>
        public void UpdateNews(NewsEditViewModel news)
        {
            var newsDB = dbSet.Find(news.Id);
            if (newsDB == null)
            {
                throw new Exception("Brak takiego artykułu!");
            }

            newsDB.Content = news.News;
            newsDB.Title = news.Title;
            newsDB.Archive = news.Archive;
            newsDB.Description = news.News.Substring(0, newsDB.Content.Length > 252 ? 252 : newsDB.Content.Length) + "...";
            newsDB.ModificationDate = DateTime.Now;

            dbSet.Attach(newsDB);
            context.Entry(newsDB).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}