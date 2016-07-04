using System.Collections.Generic;
using Domain;
using Repositories.IRepository.BaseRepository;
using Repositories.ViewModels;

namespace Repositories.IRepository
{
    /// <summary>
    /// Interface for News Repository
    /// </summary>
    public interface INewsRepository : IBaseRepository<News>
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
        void UpdateNews(NewsEditViewModel news);

        /// <summary>
        /// Get all news that are not archived
        /// </summary>
        /// <returns></returns>
        IEnumerable<News> GetAllNotArchived();
    }
}