namespace Repositories.ViewModels
{
    /// <summary>
    /// View model for news add
    /// </summary>
    public class NewsAddViewModel
    {
        /// <summary>
        /// Title of news
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// News
        /// </summary>
        public string News { get; set; }

        /// <summary>
        /// Is it ready to publish or to archive (true if to archive)
        /// </summary>
        public bool Archive { get; set; }
    }
}