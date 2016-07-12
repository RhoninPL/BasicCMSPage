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
        /// Get all news that are not archived
        /// </summary>
        /// <returns></returns>
        IEnumerable<News> GetAllNotArchived();
    }
}