using System;
using System.Collections.Generic;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.ApiResponse;
using Prufa1.ViewModels;

using Xamarin.Forms;

namespace Prufa1.Pages
{
    public partial class PopularPage : ContentPage
    {
        MovieDbConnection _database;
        ApiSearchResponse<MovieInfo> popular;

        public PopularPage(MovieDbConnection database)
        {
            _database = database;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            popular = _database.getPopular();
            if (popular != null)
            {
                updateData();
            }
            base.OnAppearing();
        }

        private void updateData()
        {

            List<MovieInfo> popularInList = new List<MovieInfo>();
            for (int i = 0; i < popular.Results.Count; i++)
            {
                popularInList.Add(popular.Results[i]);
            }

            this.BindingContext = new MovieListViewModel(this.Navigation, popularInList);
        }
    }
}
