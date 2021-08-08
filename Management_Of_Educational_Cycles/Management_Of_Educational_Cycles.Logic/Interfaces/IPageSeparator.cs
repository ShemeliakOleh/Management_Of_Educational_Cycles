using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces
{
    public interface IPageSeparator<T> where T: class
    {
        public List<T> Entities { get; set; }

        public int PageCount { get; set; }
        public int EntitiesOnPage { get; set; }

        public List<T> GetEntitesFromPage(int page);
    }
}
