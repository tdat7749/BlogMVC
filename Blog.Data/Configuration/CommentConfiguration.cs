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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);


            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId);

        }
    }
}
