using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Comments_Controller : Controller
	{
		TelefonSatisDB _db;
			public Comments_Controller(TelefonSatisDB db)//DI
		{
			_db = db;
		}

		
		public IActionResult CommentsIndex()
		{
			return View();
		}
	}
}

	