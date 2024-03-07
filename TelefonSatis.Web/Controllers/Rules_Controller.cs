using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Rules_Controller : Controller
	{
		TelefonSatisDB _db;

	public Rules_Controller(TelefonSatisDB db)//DI
	{
		_db = db;
	}
		public IActionResult RuleIndex()
		{
		var ruleList = _db.Rules.ToList();
			
			return View(ruleList);
		}
	}
}
