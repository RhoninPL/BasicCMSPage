using System.Collections.Generic;
using Domain;

namespace Repositories.IRepository
{
    /// <summary>
    /// Interface for News Repository
    /// </summary>
    public interface INewsRepository
    {
        /// <summary>
        /// Add news
        /// </summary>
        /// <param name="news"></param>
        void AddNews(News news);

        /// <summary>
        /// Update news
        /// </summary>
        /// <param name="news"></param>
        void UpdateNews(News news);

        /// <summary>
        /// Delete news
        /// </summary>
        /// <param name="id"></param>
        void DeleteNews(long id);

        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns></returns>
        IEnumerable<News> GetAllNews();

        /// <summary>
        /// Get single news
        /// </summary>
        /// <returns></returns>
        News GetNews();
    }
}