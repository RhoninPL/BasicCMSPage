using System;

namespace Repositories.ViewModels
{
    /// <summary>
    /// View Model for comments
    /// </summary>
    public class CommentsNewsViewModel
    {
        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// When comment was added
        /// </summary>
        public DateTime AddDate { get; set; }
    }
}