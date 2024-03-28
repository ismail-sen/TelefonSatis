using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
	public class SP_ProductListWithCategory
	{

        public int ProductsId { get; set; }
        public int CategoriesId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }

    }
}
