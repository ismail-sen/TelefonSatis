using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
    public class Products_Controller : Controller
    {
        //Linq, Katmanlı mimariler, UnitOf Work, Repository Design pattern olmadan bu sayfa test amaçlı (bahsedilen yapılar olmadan nasıl proje kullanılır örneği için) açıldı
        TelefonSatisDB _db;
        public Products_Controller(TelefonSatisDB db)//DI
        {
            _db = db;
        }

        public IActionResult ProductIndex()
        {
            var productList = _db.Products.ToList();//Bütün Products tablosundaki dataları ToList() ile listelemiş olduk

            return View(productList);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            
            var product = _db.Products.ToList();
            ViewBag.Products = product;
            ViewBag.Category=_db.Categories.ToList();
           // ViewData["Category"] = category;
            //TempData["Category"] = category;//daha büyük datalar için kullanılır

            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(string productName, string price, string stock, int categoriesId)
        {

            Products ekle = new Products();
            ekle.ProductName = productName;
            ekle.Price = Convert.ToDecimal(price);
            ekle.Stock = Convert.ToInt32(stock);
            ekle.CategoryId = categoriesId;
            ekle.CreateDate = DateTime.Now;
            ekle.UserId = 0;
            //datalar , db deki tabloya atılması için eşitleme yapıldı
            _db.Products.Add(ekle);
            int saveProduct = _db.SaveChanges();//ekleme başarılı ise 1 döner

            if (saveProduct > 0)
            {
                ViewBag.mesaj = "<b style='color:green'>"+productName+" ürünü başarılı bir şekilde eklendi</b>";
            }
            else
            {
                ViewBag.mesaj = "<b style='color:red'>" + productName + " ürünü eklenemedi</b>";

            }
            var category = _db.Categories.ToList();
            ViewBag.Category = category;

            return View();
        }


        //get
        public ActionResult UpdateProduct(int Id)
        {
            return View();
        }

		[HttpPost]
        public ActionResult UpdateProduct()
		{
			return View();
		}


	}
}

