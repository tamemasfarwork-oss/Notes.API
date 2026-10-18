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
    public class ImageConfig : IEntityTypeConfiguration<Image>

    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.imageID);
            // note   even if iam not wrtie the under line it will be the same thing
            builder.Property(x => x.pathimage).IsRequired(true);

            

        }

    }
}
