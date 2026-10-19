using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Data.config
{
    public class UserConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.userid);
            // note   even if iam not wrtie the under line it will be the same thing
            builder.Property(x => x.userid).IsRequired();
            builder.Property(x => x.user_name).HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.email).HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.passwordhash).HasMaxLength(100)
                .IsRequired();

            //builder.HasMany(x => x.Categories)
            //    .WithOne(s => s.users)
            //    .HasForeignKey(c => c.userid)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(x => x.Note)
            //   .WithOne(s => s.users)
            //   .HasForeignKey(c => c.userid)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(x => x.images)
            //   .WithOne(s => s.users)
            //   .HasForeignKey(c => c.userid)
            //   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
