using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
    public class Products_Controller : Controller
    {
        //Linq, Katmanlı mimariler, UnitOf Work, Repository Design pattern olmadan bu sayfa test amaçlı (bahsedilen yapılar olmadan nasıl proje kullanılır örneği için) açıldı
        TelefonSatisDB _db;
        public Products_Controller(TelefonSatisDB db)//DI
        {
                _db= db;
        }

        public IActionResult ProductIndex()
        {
           var productList = _db.Products.ToList();//Bütün Products tablosundaki dataları ToList() ile listelemiş olduk

            return View(productList);
        }
    }
}
