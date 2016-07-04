using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels
{
    /// <summary>
    /// View model for edit news
    /// </summary>
    public class NewsEditViewModel
    {
        /// <summary>
        /// ID News
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Title news
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// News
        /// </summary>
        public string News { get; set; }

        /// <summary>
        /// Archive or public
        /// </summary>
        public bool Archive { get; set; }
    }
}
