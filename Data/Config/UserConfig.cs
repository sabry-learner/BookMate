using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookMate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMate.Enums;

namespace BookMate.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure (EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("NVARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x => x.Email).HasColumnType("NVARCHAR").HasMaxLength(256).IsRequired();
            builder.Property(x => x.JoinDate).HasColumnType("date").IsRequired();
         
            builder.OwnsOne(x => x.GenreStats, gs =>
            {
                gs.Property(p => p.FavoriteGenre).HasColumnType("nvarchar").HasMaxLength(256);
                gs.Property(p => p.TotalPagesRead).HasColumnType("int");
                gs.Property(p => p.AverageRating).HasColumnType("float");
            }
            );
            builder.HasData(SeedData.GetUsers()); 
            //not work because hasData not work with owned entity type like GenreStats
            // but i don't add data for this property 
            // i can add data for it in migration file or in main program
            builder.ToTable("Users");
        }
    }

   


}
