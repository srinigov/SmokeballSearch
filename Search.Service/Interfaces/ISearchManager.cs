using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Service.Interfaces
{
    public interface ISearchManager : IManager
    {
        List<string> RetrieveSearchResultFromRespository(string searchString);
    }
}
