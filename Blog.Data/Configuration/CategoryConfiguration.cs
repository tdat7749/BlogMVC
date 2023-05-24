using Blog.Data.Entities;
using Blog.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.Disable);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);

        }
    }
}
