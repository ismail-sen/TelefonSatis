using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Categories_Controller : Controller
	{
		
		TelefonSatisDB _db;

	public Categories_Controller(TelefonSatisDB db)//DI
	{
		_db = db;
	}
		public IActionResult CategoryIndex()

		{
			var categoryList = _db.Categories.ToList();//Bütün Products tablosundaki dataları ToList() ile listelemiş olduk
			return View(categoryList);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			var category = _db.Categories.ToList();
			ViewBag.Category = category;
			//ViewData["Category"] = category;
			//TempData["Category"] = category;//daha büyük datalar için kullanılır

			return View();
		}


		[HttpPost]
		public IActionResult AddCategory(string categoryName)
		{

			Categories ekle = new Categories();
			ekle.CategoryName = categoryName;
			
			//datalar , db deki tabloya atılması için eşitleme yapıldı
			_db.Categories.Add(ekle);
			int saveCategory = _db.SaveChanges();//ekleme başarılı ise 1 döner

			if (saveCategory > 0)
			{
                ViewBag.mesaj = "<b style='color:green'>" + categoryName + " ürünü başarılı bir şekilde eklendi</b>";
            }
            else
            {
                ViewBag.mesaj = "<b style='color:red'>" + categoryName + " ürünü eklenemedi</b>";

            }
            //var category = _db.Categories.ToList();
            //ViewBag.Category = category;

            return View();
		}
        //get
        public ActionResult UpdateCategory(int Id)
        {
            //Linq ile select *from Products where ProductsId=1000 kodun aynısı aşağıdaki gibi olacaktır
            var getCategoryFind = _db.Categories.Where(k => k.CategoriesId == Id).FirstOrDefault();
            //Where
            //FirstOrDefault=> eşleşen ilk değeri getirir
            //EF- Linq ile kodlama 8-9 kod yapısı var , nettten bakılabilir
            try
            {
                ViewBag.categoryName = _db.Categories.Where(k => k.CategoriesId == getCategoryFind.CategoriesId).FirstOrDefault().CategoryName;

            }
            catch (Exception)
            {
            }

            //yukardaki linq , sql karşılığı select CategoryName from Categories where CategoriesId=2 şeklindedir

            ViewBag.Category = _db.Categories.ToList();
            return View(getCategoryFind);
        }

        [HttpPost]
        public ActionResult Updatecategory(int CategoriesId, string categoryName )
        {
            try
            {
                var getCategory = _db.Categories.Where(k => k.CategoriesId == CategoriesId).FirstOrDefault();
                //DB'deki isim = güncellenmek istenen isim
                getCategory.CategoryName = categoryName;
                

                int update = _db.SaveChanges();


                ViewBag.Category = _db.Categories.ToList();

                if (update > 0)
                {
                    //işlem başarılı
                    ViewBag.mesaj = "<b style='color:green'>ürün başarılı bir şekilde güncellendi</b>";
                    return View(getCategory);
                }
                else
                {
                    ViewBag.mesaj = "<b style='color:red'> ürün güncenlenemedi</b>";
                    return View();
                }

            }
            catch (Exception)
            {

                return View("Error");//bir sayfası
            }
        }
        public ActionResult DeleteCategory(int Id)
        {
            try
            {
                var getCategory = _db.Categories.Where(k => k.CategoriesId == Id).FirstOrDefault();
                if (getCategory != null)
                {
                    return View(getCategory);
                }
            }
            catch (Exception)
            {
            }

            return View();
        }

        [ActionName("DeleteCategory")]
        [HttpPost]
        public ActionResult CategoryRemove(int CategoryId)
        {

            try
            {
                var deleteCategory = _db.Categories.Where(k => k.CategoriesId == CategoryId).FirstOrDefault();
                if (deleteCategory != null)
                {

                    _db.Categories.Remove(deleteCategory);
                    int removeSave = _db.SaveChanges();
                    if (removeSave > 0)
                    {
                        ViewBag.mesajSil = "Başarılı şekilde silindi";

                        return RedirectToAction("CategoryIndex");
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
    }
}


		

