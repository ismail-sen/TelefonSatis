using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
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
		[HttpGet]
		public IActionResult AddRule()
		{
			var rule = _db.Rules.ToList();
			ViewBag.Rules = rule;
			//ViewData["Category"] = category;
			//TempData["Category"] = category;//daha büyük datalar için kullanılır

			return View();
		}

		[HttpPost]
        public IActionResult AddRule(string ruleName, string description)
        {

            Rules ekle = new Rules();
            ekle.RulesName = ruleName;
            ekle.Description = description;
            
            _db.Rules.Add(ekle);
            int saveProduct = _db.SaveChanges();//ekleme başarılı ise 1 döner

            if (saveProduct > 0)
            {


            }
            

            return View();
        }
    }
}
