using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Data.Interfaces
{
    public interface ISearchRepository : IRepository
    {
        List<string> GetSearchResult(string searchString);
    }
}
