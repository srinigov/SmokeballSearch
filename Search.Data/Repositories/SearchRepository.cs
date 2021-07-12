using GoogleAPI.API;
using Search.Data.Interfaces;
using Search.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Data.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        public SearchResult SearchResult { get; set; }

        public SearchRepository()
        {

        }

        //public SearchResult GetSearchResult(string searchString)
        public List<string> GetSearchResult(string searchString)
        {
            //var searchItem = new SearchResult();
            var resultList = new List<string>();

            var googleSearchData = GoogleAPISearch.RetrieveCustomSearchData(searchString);

            /*var smokeballResult = from t in googleSearchData
                                  where t.Link.Contains("smokeball")
                                  select t;*/
            int index = 0;
            foreach (var item in googleSearchData)
            {
                index++;
                if (item.Link.Contains("smokeball"))
                {
                    resultList.Add(index.ToString());
                }
            }
            return resultList;
        }
    }
}
