using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Search.Service.Manager;
using SmokeballSearch.ViewModels;
using SmokeballSearch;
using Unity;
using Search.Service.Interfaces;

namespace SmokeballSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnityContainer objContainer = new UnityContainer();
        SearchViewModel SearchVM;

        public MainWindow()
        {
            InitializeComponent();

            objContainer.RegisterType<SearchViewModel>();
            objContainer.RegisterType<ISearchManager, SearchManager>();
            SearchVM = objContainer.Resolve<SearchViewModel>();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchstring = SearchBox.Text;

            if (searchstring == "")
            {
                MessageBox.Show("The search string cannot be empty. Please enter a valid string", "Warning!");
            }
            else
            {
                //gridResult.DataContext = SearchVM.RetrieveSearchResult(searchstring);
                var result = SearchVM.RetrieveSearchResult(searchstring);
                ResultLabel.Content = string.Join(",", result);
            }
        }
    }
}
