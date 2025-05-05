using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using BookMate.Entities;
using BookMate.Data.Config;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Book> Books {  get; set; }
        public DbSet<BookSuggestion> BookSuggestions {  get; set; }
        public DbSet<ReadingSession> ReadingSessions {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectonSring = config.GetSection("constr").Value;  
            optionsBuilder.UseSqlServer(connectonSring);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
