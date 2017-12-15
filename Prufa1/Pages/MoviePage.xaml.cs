using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

namespace Prufa1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviePage : ContentPage
    {
        //Fyrir preview'ið í editornum
        public MoviePage(){

            var _ReleaseDate = new { Year = "1992" };
            var movie = new { Title = "Blad", ReleaseDate = _ReleaseDate, PosterPath = "/nBNZadXqJSdt05SHLqgT0HuC5Gm.jpg" };

            this.BindingContext = movie;
            InitializeComponent();
        }

        public MoviePage(MovieInfo movie)
        {
            this.BindingContext = movie;
            InitializeComponent();
        }
    }
}