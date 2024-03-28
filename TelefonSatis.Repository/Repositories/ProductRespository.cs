using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    public class ProductRespository : GenericRepository<Products>, IProductRepository
    {
        public ProductRespository(TelefonSatisDB db) : base(db)
        {
        }

        public int ProductCountWithCategory(int categoryId)
        {
            var getirUrunler = _db.Products.Where(k => k.CategoryId == categoryId);
            return getirUrunler.Count();
        }
        public int ProductCountWithUser(int UserId)
        {
            var getirUrunler = _db.Products.Where(k => k.UserId == UserId);
            return getirUrunler.Count();
        }

        public List<Products> ProductListWithCategory(int categoryId)
        {
            var list = _db.Products.Where(k => k.CategoryId == categoryId).ToList();
            return list;

        }

		public List<SP_ProductListWithCategory> ProductListWithCategory()
		{
            var list = _db.SP_ProductListWithCategories();
            return list;
		}
	}
}
