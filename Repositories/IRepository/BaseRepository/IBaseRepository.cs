using System.Collections.Generic;

namespace Repositories.IRepository.BaseRepository
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseRepository<TModel>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// Get one item
        /// </summary>
        /// <returns></returns>
        TModel Get(long id);

        /// <summary>
        /// Delete item
        /// </summary>
        void Delete(long id);
    }
}