using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
    public class Comments:BaseEntity
    {

        public int CommentsId { get; set; }//PK çoğul
        public string CommentsText { get; set; }
        public int ProductId { get; set; }//FK tekil
        //public Products Products { get; set; }
        //public Users Users { get; set; }

    }
}
