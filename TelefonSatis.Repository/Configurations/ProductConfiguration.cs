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
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            //tablo kolonlarının özelliklerini atamak için Configuration kullanılır
            //k=> k. => Linq=> C# içinde sql kodlamayı sağlar

            builder.HasKey(k => k.ProductsId);//PK özelliği atar
            //builder.Property(k => k.ProductsId).UseIdentityColumn(1, 1);//seed ve Increment değerleri
            builder.Property(k => k.ProductsId).IsRequired(true).UseIdentityColumn(1000,100);
            builder.Property(k => k.ProductName).IsRequired(true).HasMaxLength(250);
            builder.Property(m => m.Price).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.Property(m => m.Stock).IsRequired(true).HasColumnType("int");
           //bağlantı yapmak
          // builder.HasOne(k=>k.Category).WithMany(k=>k.Products).HasForeignKey(k=>k.CategoryId);//Product ile Categoreis arasında 1-Sonsuz bağlantı yapıldı

            builder.HasMany(k => k.Comments).WithOne(k => k.Products).HasForeignKey(k => k.ProductId);

            builder.HasOne(k => k.Users).WithMany(k => k.Products).HasForeignKey(k => k.UserId);
            //bu yorum deneme amaçlı yapıldı


        }
    }
}
