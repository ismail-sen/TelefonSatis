using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Users_Controller : Controller
	{
		TelefonSatisDB _db;

	public Users_Controller(TelefonSatisDB db)//DI
	{
		_db = db;
	}
		
		public IActionResult UserIndex()
		{
			var userList = _db.Categories.ToList();
			return View(userList);
		}
	}
}

	