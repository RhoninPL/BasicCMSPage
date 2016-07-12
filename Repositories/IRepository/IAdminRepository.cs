using System.Collections.Generic;
using Domain;
using Repositories.IRepository.BaseRepository;
using Repositories.ViewModels;

namespace Repositories.IRepository
{
    /// <summary>
    /// Interface of repository for admin
    /// </summary>
    public interface IAdminRepository : IBaseRepository<News>
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
        
    }
}