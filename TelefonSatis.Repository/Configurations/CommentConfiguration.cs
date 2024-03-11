using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder) 
        {
            builder.HasKey(x => x.CommentsId);
            builder.Property(x => x.CommentsId).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CommentsText).IsRequired(true).HasMaxLength(2000);
            builder.Property(k => k.ProductId).IsRequired(true);
           // builder.Property(k => k.UserId).IsRequired(true);
            builder.Property(k => k.CreateDate).IsRequired(true).HasColumnType("DateTime");

           // builder.HasOne(k => k.Users).WithMany(k => k.Comments);//.HasForeignKey(k => k.UserId);
            // builder.HasOne(k => k.Products).WithMany(k => k.Comments).HasForeignKey(k => k.ProductId);

        }
    }
}
