using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Entities
{
    
    public class BookSuggestion
    {
        public int Id { get; set; }
        public string SuggestionText { get; set; }
        public DateTime SuggestedAt { get; set; }
        public User User { get; set; } 
        public int UserId { get; set; }

    }
}
