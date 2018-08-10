using System;
using System.Collections.Generic;

namespace TaskLinker.Model
{
    [Serializable]
    public class RepositoryViewModel
    {
        public RepositoryViewModel()
        {
            Group = new List<UrlGroupViewModel>();
        }

        public List<UrlGroupViewModel> Group { get; set; }
    }
}
