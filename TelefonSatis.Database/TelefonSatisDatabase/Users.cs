using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
    public class Users
    {
        public int UsersId { get; set; }//PK

        public string UserName { get; set; }
        public string Surname { get; set; }
        public int Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int RuleId { get; set; }
        public DateTime CreateDate { get; set; }
        public Rules Rules { get; set; }    
        public List< Products> Products { get; set; }
        public List<Comments> Comments { get; set; }
        //Örnek
        

    }
} 
