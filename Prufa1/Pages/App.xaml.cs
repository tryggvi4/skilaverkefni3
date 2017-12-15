using Xamarin.Forms;
using System;
using DM.MovieApi.MovieDb.Movies;
using DM.MovieApi.ApiResponse; 

namespace Prufa1.Pages
{
    public partial class App : Application
    {
        MovieDbConnection _database;

        public App()
        {

            _database = new MovieDbConnection();

            InitializeComponent();

            var movieSearchPage = new MainPage(_database);
            var movieSearchNavigationPage = new NavigationPage(movieSearchPage);
            movieSearchNavigationPage.Title = "Movie Search";

            var topRatedPage = new TopRatedPage(_database);
            var topRatedNavigationPage = new NavigationPage(topRatedPage);
            topRatedNavigationPage.Title = "Top Rated Movies";

            var popularPage = new PopularPage(_database);
            var popularNavigationPage = new NavigationPage(popularPage);
            popularNavigationPage.Title = "Popular Movies";

            var tabbedPage = new LoadAfterTabBar(_database);
            tabbedPage.Children.Add(movieSearchNavigationPage);
            tabbedPage.Children.Add(popularNavigationPage);
            tabbedPage.Children.Add(topRatedNavigationPage);
            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
