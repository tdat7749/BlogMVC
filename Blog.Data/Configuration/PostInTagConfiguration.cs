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
    public class PostInTagConfiguration : IEntityTypeConfiguration<PostInTag>
    {
        public void Configure(EntityTypeBuilder<PostInTag> builder)
        {
            builder.ToTable("PostInTags");
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Post).WithMany(x => x.PostInTags).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Tag).WithMany(x => x.PostInTags).HasForeignKey(x => x.TagId);
        }
    }
}
