using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Configuration
{
    public class CarouselConfiguration : IEntityTypeConfiguration<Carousel>
    {
        public void Configure(EntityTypeBuilder<Carousel> builder)
        {
            builder.ToTable("Carousels");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.SortOrder).IsRequired();

            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
