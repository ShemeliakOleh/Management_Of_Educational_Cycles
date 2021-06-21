using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
   public class PageSeparator <T> : IPageSeparator<T> where T : class
    {
        private int pageCount;
        public List<T> Entities { get; set; }

        public int PageCount {

            get
            {
                return pageCount;
            }
            set
            {
                var pages = Entities.Count / EntitiesOnPage;
                if(Entities.Count - (pages * EntitiesOnPage) != 0)
                {
                    pages++;
                }
                pageCount = pages;
            }
        
        }
        public int EntitiesOnPage { get; set; }

        public List<T> GetEntitesFromPage (int page)
        {
            if(page<= pageCount)
            {
                var listOfEntities = new List<T>();
                var endIndex = page * EntitiesOnPage;
                var startIndex = (endIndex - EntitiesOnPage) + 1;
                if(page == PageCount)
                {
                    if(Entities.Count - endIndex != 0)
                    {
                        endIndex = Entities.Count;
                    }
                }
                for(int i = startIndex; i<=endIndex; i++)
                {
                    listOfEntities.Add(Entities[i]);
                }
                return listOfEntities;
            }
            else { throw new Exception(typeof(T).ToString());
            
            }
        }


    }
}
