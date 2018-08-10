using System;
using System.Collections.Generic;

namespace TaskLinker.Model
{
    [Serializable]
    public class UrlGroupViewModel
    {
        public UrlGroupViewModel()
        {
            UrlList = new List<UrlViewModel>();
        }

        public string GroupName { get; set; }

        public List<UrlViewModel> UrlList { get; set; }
    }
}