using Search.Data.Repositories;
using Search.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Search.Service.Interfaces;
using Search.Data.Interfaces;

namespace Search.Service.Manager
{
    public class SearchManager : ISearchManager
    {
        private SearchResult SearchResult { get; set; }
        private SearchRepository SearchRepository { get; set; }

        public SearchManager()
        {
            SearchRepository = new SearchRepository();
        }

        public List<string> RetrieveSearchResultFromRespository(string searchString)
        {
            var searchResult = SearchRepository.GetSearchResult(searchString);

            return searchResult;
        }
    }
}
