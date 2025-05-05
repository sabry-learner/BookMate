using BookMate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookMate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title).HasColumnType("NVARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Author).HasColumnType("NVARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Pages).HasColumnType("INT").IsRequired();
            builder.Property(x => x.DifficultyLevel).HasConversion(x => x.ToString(),

                x => (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), x)
                ).IsRequired();
            builder.Property(x => x.Genre).HasConversion(x => x.ToString(),

               x => (GenreType)Enum.Parse(typeof(GenreType), x)
               ).IsRequired();
            builder.HasData(SeedData.GetBooks());
            builder.ToTable("Books");
        }
    }
}
