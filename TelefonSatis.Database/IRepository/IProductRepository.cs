using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonSatis.Database.TelefonSatisDatabase;

namespace TelefonSatis.Database.IRepository
{
    public interface IProductRepository:IGenericRepository<Products>
    {
        //IGenericRepository dışında kodlaman geeken bir method varsa onu da ek olarak bu ksımda tanımlamak gereklidir

        int ProductCountWithCategory(int categoryId);//Kategoriye göre ürün sayısı

    }
}
