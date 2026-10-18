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
    public class NontesConfig : IEntityTypeConfiguration<Note>

    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.notesID);
            // note   even if iam not wrtie the under line it will be the same thing
            builder.Property(x => x.should_review_it);

            builder.Property(x => x.content)
                .IsRequired(false);

            builder.Property(x => x.is_pinned)
               ;

            builder.Property(x => x.title).HasMaxLength(255)
                .IsRequired(false);


            builder.HasMany(x => x.images)
                .WithOne(s => s.note)
                .HasForeignKey(s => s.noteID)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Categories)
                .WithMany(s => s.notes)
                .HasForeignKey(s => s.CatigoryID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
