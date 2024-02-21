using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
    public class Products:BaseEntity // Tablo Adı
    {
        public int ProductsId { get; set; }//KolonAdı
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }//kolon
        public Categories Category { get; set; }//kolon değil relationship yapısıdır
        public List<Comments> Comments { get; set; }  //relationship
        public Users Users { get; set; }


    }
}
