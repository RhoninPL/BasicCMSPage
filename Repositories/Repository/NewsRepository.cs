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

        /// <summary>
        /// Add news to the DB
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News newsDB)
        {
            newsDB.AddDate = DateTime.Now;
            newsDB.ModificationDate = DateTime.Now;
            newsDB.Description = newsDB.Content.Substring(0, newsDB.Content.Length > 252 ? 252 : newsDB.Content.Length) + "...";
            newsDB.UsersId = 1; // TODO: change 1 to id of user
            dbSet.Add(newsDB);
            context.SaveChanges();
        }

        /// <summary>
        /// Update news in DB
        /// </summary>
        /// <param name="news"></param>
        public void UpdateNews(NewsEditViewModel newsEdit)
        {
            var newsDB = dbSet.Find(newsEdit.Id);
            if (newsDB == null)
            {
                throw new Exception("Brak takiego artykułu!");
            }
            newsDB.Content = newsEdit.News;
            newsDB.Title = newsEdit.Title;
            newsDB.Archive = newsEdit.Archive;
            newsDB.Description = newsEdit.News.Substring(0, newsDB.Content.Length > 252 ? 252 : newsDB.Content.Length) + "...";
            newsDB.ModificationDate = DateTime.Now;

            dbSet.Attach(newsDB);
            context.Entry(newsDB).State = EntityState.Modified;
            
            context.SaveChanges();
        }

        public IEnumerable<News> GetAllNotArchived()
        {
            IEnumerable<News> dbNews = dbSet.Where(x => x.Archive == false)
                .OrderByDescending(x => x.ModificationDate);
            return dbNews;
        }
    }
}