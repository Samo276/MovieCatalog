global using System;

namespace MovieCatalog.Data
{
    public class MovieEntry
    {
        public int Id { get; set; }
        public DateTime EntryCreationTime { get; set; }
        public DateTime PremiereTime { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public MovieEntry(int id, DateTime entryCreationTime, DateTime premiereTime, string genre, string title, string description)
        {
            Id = id;
            EntryCreationTime = entryCreationTime;
            PremiereTime = premiereTime;
            Genre = genre;
            Title = title;
            Description = description;
        }

    }
}
