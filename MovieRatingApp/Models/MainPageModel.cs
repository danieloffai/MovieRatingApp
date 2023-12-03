using MovieRatingApp.Classes;
using System.Collections.ObjectModel;

namespace MovieRatingApp.Models
{
    public class MainPageModel
    {
        public ObservableCollection<Movie> Movies { get; }

        public MainPageModel()
        {
            Movies = new ObservableCollection<Movie>
            {
                new Movie { MoviePicture = "aliens.png", MovieName = "Aliens", Stars = 5, Color = Colors.Black },
                new Movie { MoviePicture = "suicidesuqad.png", MovieName = "Suicide Squad", Stars = 4, Color = Colors.PeachPuff },
                new Movie { MoviePicture = "starwars.png", MovieName = "Star Wars", Stars = 2, Color = Colors.IndianRed },
            };
        }
    }
}
