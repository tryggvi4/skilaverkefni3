using System;
using Prufa1.Pages;
using Xamarin.Forms;

namespace Prufa1
{
    public class LoadAfterTabBar : TabbedPage
    {
        MovieDbConnection _database;

        public LoadAfterTabBar(MovieDbConnection database)
        {
            _database = database;
        }

        protected override void OnAppearing()
        {
            
            setData();

            base.OnAppearing();
        }

        public void setData(){
            //TODO bæta við popular
            try
            {
                MovieDbConnection.setTopRated();
                MovieDbConnection.setPopular();
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
