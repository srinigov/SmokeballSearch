using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Google;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using GoogleAPI;

namespace GoogleAPI.API
{
    public static class GoogleAPISearch
    {
        public static List<Result> RetrieveCustomSearchData(string searchString)
        {
            const string apiKey = "AIzaSyBoq4FTIGyFT0_HSXS1Pa2S-vQ4Ge-uwLI";
            const string searchEngineId = "60dc590eda9673ef4";

            var customSearch = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listSearchResult = customSearch.Cse.List();

            listSearchResult.Cx = searchEngineId;
            listSearchResult.Q = searchString;

            List<Result> resultData = new List<Result>();

            int count = 0;

            while (resultData != null && count < 10)
            {
                listSearchResult.Start = count;
                listSearchResult.Execute().Items?.Take(10).ToList().ForEach(x => resultData.Add(
                    new Result
                    {
                        Content = x.Snippet,
                        Link = x.Link,
                        Title = x.Title,
                        Name = x.HtmlTitle
                    }
                    ));
                count++;
            }
            return resultData;
        }
    }
}
