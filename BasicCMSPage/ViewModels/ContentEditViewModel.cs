using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicCMSPage.ViewModels
{
    public class ContentEditViewModel
    {
        public string Name;
        public string Content;
        public bool Visible;
        public DateTime LastModify;
        public DateTime CreationDateTime;
    }
}