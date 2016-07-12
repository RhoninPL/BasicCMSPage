using System;

namespace Repositories.ViewModels
{
    /// <summary>
    /// News list view model for admin
    /// </summary>
    public class NewsAdminListViewModel
    {
        /// <summary>
        /// Identification of news
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Title of news
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Add date
        /// </summary>
        public DateTime AddDateTime { get; set; }

        /// <summary>
        /// Modification date
        /// </summary>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        /// Author of news
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Views of news
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// How many comments there are
        /// </summary>
        public int CommentsCount { get; set; }

        /// <summary>
        /// Description of news
        /// </summary>
        public string Description { get; set; }
    }
}