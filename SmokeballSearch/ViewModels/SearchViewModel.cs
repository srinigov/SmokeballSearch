using Search.Data.Interfaces;
using Search.Data.Repositories;
using Search.Infrastructure.Models;
using Search.Service.Interfaces;
using Search.Service.Manager;
using SmokeballSearch.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace SmokeballSearch.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private ISearchManager SearchManager;

        IUnityContainer objContainer = new UnityContainer();
        SearchManager SearchM;

        public SearchViewModel(ISearchManager SearchManager)
        {
            this.SearchManager = SearchManager;

            objContainer.RegisterType<SearchManager>();
            objContainer.RegisterType<ISearchRepository, SearchRepository>();
            SearchM = objContainer.Resolve<SearchManager>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string parameter)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
        }

        private ICommand _ResultCommand;
        public ICommand ResultCommand
        {
            get
            {
                if (_ResultCommand == null)
                {
                    _ResultCommand = new RelayCommand(ResultExecute, canResultExecute, false);
                }
                return _ResultCommand;
            }
        }

        public void ResultExecute(object parameter)
        {
            
        }

        public bool canResultExecute(object parameter)
        {
            return true;
        }

        public List<string> RetrieveSearchResult(string searchString)
        {
            var searchResult = SearchManager.RetrieveSearchResultFromRespository(searchString);

            return searchResult;
        }
    }
}
