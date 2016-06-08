using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain;
using Repositories.IRepository;

namespace Repositories.Repository
{
    /// <summary>
    /// Repository for news DB
    /// </summary>
    public class NewsRepository : DBContainer,INewsRepository
    {
        /// <summary>
        /// Add news to the DB
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News news)
        {
            NewsSet.Add(news);
            this.SaveChanges();
        }

        /// <summary>
        /// Update news in DB
        /// </summary>
        /// <param name="news"></param>
        public void UpdateNews(News news)
        {
            // newsDb = NewsSet.FirstOrDefault(x => x.Id == news.Id);
            //if (newsDb == null)
            //{
            //    throw new Exception("No entity found!");
            //}

            //newsDb = news;
            NewsSet.Attach(news);
            this.Entry(news).State = EntityState.Modified;
            this.SaveChanges();
        }

        /// <summary>
        /// Delete news in DB
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNews(long id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get all news from DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<News> GetAllNews()
        {
            IEnumerable<News> dbNews = NewsSet.OrderByDescending(x => x.Id);
            return dbNews;
        }

        /// <summary>
        /// Get single news from DB
        /// </summary>
        /// <returns></returns>
        public News GetNews(long id)
        {
            return NewsSet.FirstOrDefault(x => x.Id == id);
        }
    }
}