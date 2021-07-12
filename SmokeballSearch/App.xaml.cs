using Search.Service.Interfaces;
using Search.Service.Manager;
using SmokeballSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace SmokeballSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private IUnityContainer objContainer;

        public App()
        {
            objContainer = new UnityContainer();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            objContainer.RegisterType<SearchViewModel>();
            objContainer.RegisterType<ISearchManager, SearchManager>();
        }
    }
}
