using BookMate.Entities;
using BookMate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Data
{
    public static class SeedData
    {
        public static List<User> GetUsers()
        {
            return new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Ahmed Sabry",
                Email = "ahmed@example.com",
                JoinDate = new DateTime(2020, 1, 1)
               
            },
            new User
            {
                Id = 2,
                Name = "Mona Ali",
                Email = "mona@example.com",
                JoinDate = new DateTime(2022, 5, 1)
            }
        };
        }

        public static List<Book> GetBooks()
        {
            return new List<Book>
        {
            new Book
            {
                Id= 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Genre = GenreType.Science,
                Pages = 464,
                DifficultyLevel = DifficultyLevel.Hard
            },
            new Book
            {
                Id = 2,
                Title = "The Alchemist",
                Author = "Paulo Coelho",
                Genre = GenreType.Fiction,
                Pages = 208,
                DifficultyLevel = DifficultyLevel.Easy
            }
        };
        }

        public static List<ReadingSession> GetReadingSessions()
        {
            return new List<ReadingSession>
        {
            new ReadingSession
            {
                Id =1,
                UserId = 1,
                BookId = 1,
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(11, 0, 0),
                Mood = Mood.Relaxed,
                Notes = "Great focus session.",
                Rating = 5
            },
            new ReadingSession
            {
                Id = 2,
                UserId = 2,
                BookId = 2,
                StartTime = new TimeSpan(14, 30, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Mood = Mood.Tired,
                Notes = "Lost concentration.",
                Rating = 2
            }
        };
        }

        public static List<BookSuggestion> GetBookSuggestions()
        {
            return new List<BookSuggestion>
        {
            new BookSuggestion
            {
                Id = 1,
                UserId = 1,
                SuggestionText = "You must read 'Atomic Habits'.",
                SuggestedAt =new DateTime(2023, 1, 1)
            },
            new BookSuggestion
            {
                Id=2,
                UserId = 2,
                SuggestionText = "Try reading '1984' by George Orwell.",
                SuggestedAt = new DateTime(2024, 4, 4)
            }
        };
        }
    }

}
