using BookMate.Entities;
using BookMate.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMate.Data.Config
{

    public class ReadingSessionConfig : IEntityTypeConfiguration<ReadingSession>
    {
        public void Configure(EntityTypeBuilder<ReadingSession> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Notes).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Mood).HasConversion(x => x.ToString(),

                x => (Mood)Enum.Parse(typeof(Mood), x)
                );
            builder.Property(x => x.StartTime).HasColumnType("time(0)").IsRequired();
            builder.Property(x => x.EndTime).HasColumnType("time(0)").IsRequired();
            builder.Property(x => x.Rating).HasColumnType("INT").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.ReadingSessions).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book).WithMany(x => x.ReadingSessions).HasForeignKey(x => x.BookId);
            builder.HasData(SeedData.GetReadingSessions());
            builder.ToTable("ReadingSessions");
        }
    }


}
