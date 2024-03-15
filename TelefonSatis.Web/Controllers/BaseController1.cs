using Microsoft.AspNetCore.Mvc;

namespace TelefonSatis.Web.Controllers
{
	public class BaseController1 : Controller
	{

		public int UserId = 2;
        public IActionResult Index()
		{
			return View();
		}
	}
}
