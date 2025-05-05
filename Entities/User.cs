using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public List<ReadingSession>? ReadingSessions { get; set; }
        public List<BookSuggestion> BookSuggestions { get; set; } = new List<BookSuggestion>();
        public GenreStats? GenreStats { get; set; } // Owned Type

    }
    public class GenreStats
    {
        public string FavoriteGenre { get; set; }
        public int TotalPagesRead { get; set; }
        public float AverageRating { get; set; }
    }
}
