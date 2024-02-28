using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;


namespace TelefonSatis.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x => x.CategoriesId);
            builder.Property(x => x.CategoriesId).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CategoryName).IsRequired(true).HasMaxLength(250);
          
        }
    }
}
