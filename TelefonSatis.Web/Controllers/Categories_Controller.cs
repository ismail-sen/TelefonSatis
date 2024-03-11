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


			}
			//var category = _db.Categories.ToList();
			//ViewBag.Category = category;

			return View();
		}

	}


}


		

