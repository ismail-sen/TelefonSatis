using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
    public abstract class BaseEntity
    {
        //abstract new'lenemez
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
