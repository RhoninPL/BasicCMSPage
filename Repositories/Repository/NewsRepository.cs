using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using AutoMapper;
using Domain;
using Repositories.IRepository;
using Repositories.Repository.BaseRepository;
using Repositories.ViewModels;

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
        
        public IEnumerable<News> GetAllNotArchived()
        {
            IEnumerable<News> dbNews = dbSet.Where(x => x.Archive == false)
                .OrderByDescending(x => x.ModificationDate);
            return dbNews;
        }
    }
}