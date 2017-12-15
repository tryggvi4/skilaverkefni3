using System;
using System.Collections.Generic;
using Prufa1;

using Xamarin.Forms;

namespace Prufa1.Pages
{
    public partial class MainPage : ContentPage
    {
        MovieDbConnection _database;

        public MainPage(MovieDbConnection database)
        {

            _database = database;

            InitializeComponent();
        }

        private async void SearchButton_OnClicked(object sender, EventArgs e)
        {
            await _database.SetMovies(this.MovieEntry.Text);


            var response = _database.GetMovies();


            await this.Navigation.PushAsync(new MovieListPage(response));
        }
    }
}
