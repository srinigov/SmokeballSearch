using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Infrastructure.Models
{
    public class SearchResult
    {
        public string SearchURL { get; set; }

        public string SearchString { get; set; }

        public List<String> Result { get; set; }
    }
}
