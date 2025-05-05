using BookMate.Data;

namespace BookMate
{
    public class Program
    {

        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(SeedData.GetUsers());
                    context.Books.AddRange(SeedData.GetBooks());
                    context.ReadingSessions.AddRange(SeedData.GetReadingSessions());
                    context.BookSuggestions.AddRange(SeedData.GetBookSuggestions());
                    context.SaveChanges();
                }

                ShowSeededData(context);
            }

        }

        static void ShowSeededData(AppDbContext context)
        {
            var users = context.Users.ToList();
            var books = context.Books.ToList();
            var sessions = context.ReadingSessions.ToList();
            var suggestions = context.BookSuggestions.ToList();

            Console.WriteLine("=== Users ===");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, JoinDate: {user.JoinDate}, Favorite Genre: {user.GenreStats?.FavoriteGenre}");
            }

            Console.WriteLine("\n=== Books ===");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Pages: {book.Pages}, Difficulty: {book.DifficultyLevel}");
            }

            Console.WriteLine("\n=== Reading Sessions ===");
            foreach (var session in sessions)
            {
                Console.WriteLine($"ID: {session.Id}, UserId: {session.UserId}, BookId: {session.BookId}, Start: {session.StartTime}, End: {session.EndTime}, Mood: {session.Mood}, Rating: {session.Rating}, Notes: {session.Notes}");
            }

            Console.WriteLine("\n=== Book Suggestions ===");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine($"ID: {suggestion.Id}, UserId: {suggestion.UserId}, Suggestion: {suggestion.SuggestionText}, SuggestedAt: {suggestion.SuggestedAt}");
            }
        }
    }
}
