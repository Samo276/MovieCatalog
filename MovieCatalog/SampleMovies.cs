namespace MovieCatalog
{
    public class SampleMovies
    {
        public List<MovieEntry> Selection = new()
        {
            new MovieEntry(0,DateTime.Now.AddMinutes(-6),DateTime.Now.AddMonths(-1),Genre.Genres.comedy.ToString(),"ComedyFilm 2: Return of the Comedy","Lorem ipsum."),
            new MovieEntry(1,DateTime.Now.AddMinutes(-5),DateTime.Now.AddMonths(-2),Genre.Genres.drama.ToString(),"Dramatic drama","Lorem ipsum."),
            new MovieEntry(2,DateTime.Now.AddMinutes(-4),DateTime.Now.AddMonths(-5),Genre.Genres.horror.ToString(),"The Horror","Lorem ipsum."),
            new MovieEntry(3,DateTime.Now.AddMinutes(-3),DateTime.Now.AddMonths(-6),Genre.Genres.fantasy.ToString(),"Rabbits","Lorem ipsum."),
            new MovieEntry(4,DateTime.Now.AddMinutes(-2),DateTime.Now.AddMonths(-18),Genre.Genres.romance.ToString(),"The Great Romance","Lorem ipsum."),
            new MovieEntry(5,DateTime.Now.AddMinutes(-1),DateTime.Now.AddMonths(-19),Genre.Genres.adventure.ToString(),"Adventure, Adventure","Lorem ipsum."),
        };
        public List<MovieEntry> AddSampleMovies()
        {
            return Selection;
        }

        public SampleMovies()
        {
        }
    }
}
