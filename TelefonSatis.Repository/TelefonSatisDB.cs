using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;
using TelefonSatis.Repository.Configurations;

namespace TelefonSatis.Repository
{
    public class TelefonSatisDB : DbContext
    {
        public TelefonSatisDB(DbContextOptions<TelefonSatisDB> options):base(options)
        {
            
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SP_ProductListWithCategory> SP_ProductListCategory{ get; set; }

        public List<SP_ProductListWithCategory> SP_ProductListWithCategories()
        {
            var result = SP_ProductListCategory.FromSqlRaw("exec sp_ProductListWithCategory").ToList();//her çağırdığımda exec olmalı
            return result;

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Products>().HasKey(k => k.ProductsId);
            //modelBuilder.Entity<Products>().Property(k => k.ProductsId).IsRequired(true).UseIdentityColumn(1000, 100);
            //modelBuilder.Entity<Products>().Property(k => k.ProductName).IsRequired(true).HasMaxLength(250);
            //modelBuilder.Entity<Products>().Property(m => m.Price).IsRequired(true).HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Products>().Property(m => m.Stock).IsRequired(true).HasColumnType("int");
            //yukardaki her bir ayar burda yapmak yerine biz Configuration altında her bir tablo için ayrı ayrı yaptık. Bu alanda kod karmaşasına yapacağı için yapılması önerilmez.
            //*****************************************************************
            //her bir tablo için aşağıdaki Configuration ayarı yapılarak bütün tablo ayarları dahil edilebilir. Ama bir projede bazen 10larca, 100 lerce tablo olabilir bu da kod karmaşasında neden olacaktır. ÖNERİLMEZ
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //**************************************************
            //sadece tek bir kod yapısı ile Kalıtım verdiğimiz bütün Configuration classlarının ayarlarını alabiliriz
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SP_ProductListWithCategory>(entity =>
            {
                entity.HasNoKey();
            });

		}

    }
}
