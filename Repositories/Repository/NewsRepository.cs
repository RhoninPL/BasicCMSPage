using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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

        /// <summary>
        /// Add news to the DB
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(NewsAddViewModel news)
        {
            News newsDB = Mapper.Map<NewsAddViewModel, News>(news);
            newsDB.AddDate = DateTime.Now;
            newsDB.ModificationDate = DateTime.Now;
            char[] tmp = new char[255];
            newsDB.Content.CopyTo(0, tmp, 0, newsDB.Content.Length > 254 ? 255 : newsDB.Content.Length);
            newsDB.Description = tmp.ToString();
            newsDB.UsersId = 1;
            dbSet.Add(newsDB);
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