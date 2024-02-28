using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonSatis.Database.TelefonSatisDatabase
{
    public class Rules//table name 
    {
        public int RulesId { get; set; }
        public string RulesName { get; set; }
        public string Description { get; set; }
        //public List<Users> Users{ get; set; }

        /*
         Erişim Belirleyicileri
        Modifiers

        1-private=> Özel erişim. kullanılan sayfada tek erişime açar
        2-public=> her yerde erişime açık

        3-internal=> Kullamnıldığı projede
        4-Protected=> sadece kalıtım verilen sayfalarda erişimi var
        5-protected internal=> Aynı proje altında ve kalıtım veren sayfalarda erişim sağlar
        6-static=> new lemeden kullanma imkanı sağlar
         */

    }
}
