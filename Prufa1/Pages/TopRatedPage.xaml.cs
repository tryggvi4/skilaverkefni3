using System;
using System.Collections.Generic;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.ApiResponse;
using Prufa1.ViewModels;

using Xamarin.Forms;

namespace Prufa1.Pages
{
    public partial class TopRatedPage : ContentPage
    {
        MovieDbConnection _database;
        ApiSearchResponse<MovieInfo> topRated;

        public TopRatedPage(MovieDbConnection database)
        {
            _database = database;

            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            topRated = _database.getTopRated();
            if(topRated != null){
                updateData();
            }
            base.OnAppearing();
        }

        private void updateData(){
            List<MovieInfo> topRatedInList = new List<MovieInfo>();
            for (int i = 0; i < topRated.Results.Count; i++)
            {
                topRatedInList.Add(topRated.Results[i]);
            }

            this.BindingContext = new MovieListViewModel(this.Navigation, topRatedInList);
        }
    }
}
