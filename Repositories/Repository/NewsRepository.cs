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
    public class NewsRepository : BaseRepository<News>,INewsRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NewsRepository() : base()
        {}

        /// <summary>
        /// Add news to the DB
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News news)
        {
            dbSet.Add(news);
            context.SaveChanges();
        }

        /// <summary>
        /// Update news in DB
        /// </summary>
        /// <param name="news"></param>
        public void UpdateNews(News news)
        {
            dbSet.Attach(news);
            context.Entry(news).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<News> GetAllNotArchived()
        {
            IEnumerable<News> dbNews = dbSet.Where(x => x.Archive == false);
            return dbNews;
        }
    }
}