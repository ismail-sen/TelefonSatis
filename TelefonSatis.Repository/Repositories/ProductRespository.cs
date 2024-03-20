using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.IRepository;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Repository.Repositories
{
    internal class ProductRespository : GenericRepository<Products>, IProductRepository
    {
        public int ProductCountWithCategory(int categoryId)
        {
            var getirUrunler = _db.Products.Where(k => k.CategoryId == categoryId);
            return getirUrunler.Count();
        }
    }
}
