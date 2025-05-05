using BookMate.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Entities
{
    public class ReadingSession
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; } 
        public int BookId { get; set; }
        public  TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Mood Mood { get; set; }
        public string? Notes { get; set; }
        [Range(0 ,5)]
        public int Rating { get; set; }

    }
}
