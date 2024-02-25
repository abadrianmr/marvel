using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using VisualApp.Services;
using VisualApp.ViewModels.Navigation;

namespace VisualApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty( ref _isLoading, value ); }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { SetProperty( ref _statusMessage, value ); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty( ref _searchText, value ); }
        }

        private HeroViewModel? _selectedHeroe;
        public HeroViewModel? SelectedHeroe
        {
            get { return _selectedHeroe; }
            set { SetProperty( ref _selectedHeroe, value ); }
        }

        private readonly IHeroService _heroService;

        public ObservableCollection<HeroViewModel> Heroes { get; private set; }

        private ObservableCollection<string> _searchSugestions;
        public ObservableCollection<string> SearchSugestions
        {
            get { return _searchSugestions; }
            set { SetProperty( ref _searchSugestions, value ); }
        }

        public DelegateCommand LoadedCommand { get; private set; }
        public DelegateCommand SearchTextChangedCommand { get; private set; }
        public DelegateCommand QuerySubmittedCommand { get; private set; }

        public MainWindowViewModel( IHeroService heroService )
        {
            UpdateStatusBar( "Loading Heroes", true );
            LoadedCommand = new DelegateCommand( LoadAsync );
            SearchTextChangedCommand = new DelegateCommand( OnSearchTextChanged );
            QuerySubmittedCommand = new DelegateCommand( OnQuerySubmitted );
            Heroes = new ObservableCollection<HeroViewModel>();
            SearchSugestions = new ObservableCollection<string>();
            SearchText = string.Empty;
            _heroService = heroService;
        }

        private void OnQuerySubmitted()
        {
            SelectedHeroe = Heroes.FirstOrDefault( x => x.Name == SearchText );
        }

        private void OnSearchTextChanged()
        {
            SearchSugestions = new ObservableCollection<string>();

            var querySplit = SearchText.Split( ' ' );
            var matchingItems = Heroes.Where(
                item =>
                {
                    // Idea: check for every word entered (separated by space) if it is in the name,  
                    // e.g. for query "split button" the only result should "SplitButton" since its the only query to contain "split" and "button" 
                    // If any of the sub tokens is not in the string, we ignore the item. So the search gets more precise with more words 
                    bool flag = true;
                    foreach( string queryToken in querySplit )
                    {
                        // Check if token is not in string 
                        if( item.Name.IndexOf( queryToken, StringComparison.CurrentCultureIgnoreCase ) < 0 )
                        {
                            // Token is not in string, so we ignore this item. 
                            flag = false;
                        }
                    }
                    return flag;
                } );
            foreach( var item in matchingItems )
            {
                SearchSugestions.Add( item.Name );
            }
            if( SearchSugestions.Count == 0 )
            {
                SearchSugestions = new ObservableCollection<string>() { "No results found" };
            }
        }

        /// <summary>
        /// Initialize control. Automatically called if Control is of type Catel.UserControl.
        /// </summary>
        /// <returns>Task</returns>
        protected async void LoadAsync()
        {
            await foreach( var item in _heroService.GetHeroes() )
            {
                Heroes.Add( new( item ) );
                UpdateStatusBar( $"Loading Heroe {item.Id}", true );
            }
            UpdateStatusBar( "Loaded Completed", false );
        }

        private void UpdateStatusBar( string message, bool isloading )
        {
            IsLoading = isloading;
            StatusMessage = message;
        }
    }
}
