using BookMate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Data.Config
{

    public class BookSuggestionConfig : IEntityTypeConfiguration<BookSuggestion>
    {
        public void Configure(EntityTypeBuilder<BookSuggestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.SuggestionText).HasColumnType("NVARCHAR(MAX)");

            builder.Property(x => x.SuggestedAt).HasColumnType("datetime").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.BookSuggestions).HasForeignKey(x => x.UserId).IsRequired();
            builder.HasData(SeedData.GetBookSuggestions());
            builder.ToTable("BookSuggestions");
        }
    }
}
