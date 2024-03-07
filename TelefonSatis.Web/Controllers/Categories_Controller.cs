using Microsoft.AspNetCore.Mvc;
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
	}
}


		

