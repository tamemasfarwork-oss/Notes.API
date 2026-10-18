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
    public class CategoriesConfig: IEntityTypeConfiguration<Categories>
    {

        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.categoriesID);
            // note   even if iam not wrtie the under line it will be the same thing


            builder.Property(x => x.is_pinned);
                

            builder.Property(x => x.title).HasMaxLength(255)
                .IsRequired(false);


        }
    }
}
