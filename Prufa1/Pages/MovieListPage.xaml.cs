using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prufa1.ViewModels;

using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

namespace Prufa1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListPage : ContentPage
    {

        public MovieListPage(ApiSearchResponse<MovieInfo> response)
        {
            List<MovieInfo> responseInList = response.Results.ToList();



            this.BindingContext = new MovieListViewModel(this.Navigation, responseInList);

            InitializeComponent();
        }


    }
}
