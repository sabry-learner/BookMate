using BookMate.Enums;


namespace BookMate.Entities
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public GenreType Genre { get; set; }
        public int Pages { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public List<ReadingSession>? ReadingSessions { get; set; }
    }
}
