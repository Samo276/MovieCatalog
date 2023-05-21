using Microsoft.VisualBasic;

namespace MovieCatalog
{
    public static class IncomingMovieEntryConverter
    {
        public static MovieEntry Convert(MovieEntry incomingEntry, List<MovieEntry> data)
        {
            var newMovieEntry = new MovieEntry(
                    data.Max(maxId => maxId.Id) + 1,
                    DateAndTime.Now,
                    incomingEntry.PremiereTime,
                    incomingEntry.Genre,
                    incomingEntry.Title,
                    incomingEntry.Description
            );
            return newMovieEntry;
        }
        
    }
}
