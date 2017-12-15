using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
//using Prufa1.Model;
using Prufa1.Pages;

using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System.Windows.Input;
using System.Threading.Tasks;

using Prufa1;
using System;

namespace Prufa1.ViewModels
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private MovieInfo _selectedMovie;
        List<MovieInfo> _response;

        public MovieListViewModel(INavigation navigation, List<MovieInfo> response)
        {
            this._navigation = navigation;
            this._response = response;
        }

        public List<MovieInfo> response
        {
            get => this._response;

            set
            {
                this._response = value;
                OnPropertyChanged();
            }
        }

        public MovieInfo SelectedMovie
        {
            get => this._selectedMovie;

            set
            {
                if (value != null)
                {
                    this._selectedMovie = value;
                    this._navigation.PushAsync(new MoviePage(value), true);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    //await RefreshData();

                    IsRefreshing = false;
                });
            }
        }
    }
}
