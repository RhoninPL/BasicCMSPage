﻿using System;
using System.Collections.Generic;

namespace Repositories.ViewModels
{
    public class NewsDetailsViewModel
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
        /// News
        /// </summary>
        public string News { get; set; }

        /// <summary>
        /// Add date
        /// </summary>
        public DateTime AddDateTime { get; set; }

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
        public IEnumerable<CommentsNewsViewModel> Comments { get; set; }
    }
}