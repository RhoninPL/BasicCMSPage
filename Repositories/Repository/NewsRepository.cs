using System.Collections.Generic;
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
            throw new System.NotImplementedException();
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
        public News GetNews()
        {
            throw new System.NotImplementedException();
        }
    }
}