using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search.Service.Interfaces;
using Search.Service.Manager;
using SmokeballSearch.ViewModels;
using Unity;

namespace SearchTest
{
    [TestClass]
    public class SearchResultTest
    {
        [TestMethod]
        public void Test_Positive_RetrieveSearchResultFromGoogleAPI()
        {
            IUnityContainer objContainer = new UnityContainer();
            SearchViewModel SearchVM;

            objContainer.RegisterType<SearchViewModel>();
            objContainer.RegisterType<ISearchManager, SearchManager>();
            SearchVM = objContainer.Resolve<SearchViewModel>();

            string expected = "10,20,29,38,47,56,65,74,83,92";
            string searchString = "Conveyancing Software";
            var result = SearchVM.RetrieveSearchResult(searchString);
            string actual = string.Join(",", result);

            Assert.AreEqual(expected, actual);
        }
    }
}
