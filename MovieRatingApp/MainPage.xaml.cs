using Maui.Controls.RatingView;
using MovieRatingApp.Models;

namespace MovieRatingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageModel();
        }

        private void MyRatingView_Tapped(object sender, EventArgs e)
        {

        }
    }

}
