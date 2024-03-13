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
				ViewBag.mesaj = "<b style='color:green'>" + ruleName + " ürünü başarılı bir şekilde eklendi</b>";
			}
			else
			{
				ViewBag.mesaj = "<b style='color:red'>" + ruleName + " ürünü eklenemedi</b>";
			}

			return View();
		}

		//get
		public ActionResult UpdateRule(int Id)
		{
			//Linq ile select *from Products where ProductsId=1000 kodun aynısı aşağıdaki gibi olacaktır
			var getRuleFind = _db.Rules.Where(k => k.RulesId == Id).FirstOrDefault();
			//Where
			//FirstOrDefault=> eşleşen ilk değeri getirir
			//EF- Linq ile kodlama 8-9 kod yapısı var , nettten bakılabilir
			try
			{
				ViewBag.ruleName = _db.Rules.Where(k => k.RulesId == getRuleFind.RulesId).FirstOrDefault().RulesName;

			}
			catch (Exception)
			{
			}

			//yukardaki linq , sql karşılığı select CategoryName from Categories where CategoriesId=2 şeklindedir

			ViewBag.Rule = _db.Rules.ToList();
			return View(getRuleFind);
		}

		[HttpPost]
		public ActionResult UpdateRule(int RulesId, string ruleName, string description)
		{
			try
			{
				var getRule = _db.Rules.Where(k => k.RulesId == RulesId).FirstOrDefault();
				//DB'deki isim = güncellenmek istenen isim

				getRule.RulesName = ruleName;
				getRule.Description = description;


				int update = _db.SaveChanges();


				ViewBag.Rule = _db.Rules.ToList();

				if (update > 0)
				{
					//işlem başarılı
					ViewBag.mesaj = "<b style='color:green'>ürün başarılı bir şekilde güncellendi</b>";
					return View(getRule);
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

		//ctrl+m+o=> bütün methodların kodlarını gizle
		//ctrl+m+l=> bütün methodların kodlarını gigöster


		public ActionResult DeleteRule(int Id)
		{
			try
			{
				var getRule = _db.Rules.Where(k => k.RulesId == Id).FirstOrDefault();
				if (getRule != null)
				{
					return View(getRule);
				}
			}
			catch (Exception)
			{
			}

			return View();
		}

		[ActionName("DeleteRule")]
		[HttpPost]
		public ActionResult RuleRemove(int RuleId)
		{

			try
			{
				var deleteRule = _db.Rules.Where(k => k.RulesId == RuleId).FirstOrDefault();
				if (deleteRule != null)
				{

					_db.Rules.Remove(deleteRule);
					int removeSave = _db.SaveChanges();
					if (removeSave > 0) {
						ViewBag.mesajSil = "Başarılı şekilde silindi";

						return RedirectToAction("RuleIndex");
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
