using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Repositories.IRepository.BaseRepository;

namespace Repositories.Repository.BaseRepository
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {

        internal DBContainer context;
        internal DbSet<TModel> dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRepository()
        {
            this.context = new DBContainer();
            this.dbSet = context.Set<TModel>();
        }
        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(long id)
        {
            var objet = dbSet.Find(id);
            dbSet.Attach(objet);
            context.Entry(objet).State = EntityState.Deleted;
            context.SaveChanges();
        }

        /// <summary>
        /// Get one item
        /// </summary>
        /// <returns></returns>
        public TModel Get(long id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TModel> GetAll()
        {
            IEnumerable<TModel> dbNews = dbSet.AsEnumerable();
            return dbNews;
        }
    }
}