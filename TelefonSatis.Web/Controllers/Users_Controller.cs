using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
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
		var userList = _db.Users.ToList();
		return View(userList);
	}

	[HttpGet]
	public IActionResult AddUser()
		{
			var user = _db.Users.ToList();
			ViewBag.Users = user;
			//ViewData["Category"] = category;
			//TempData["Category"] = category;//daha büyük datalar için kullanılır

			return View();
		}


	[HttpPost]
	public IActionResult AddUser(string userName, string surName, string address, string email, string password, int ruleId)
		{

			Users ekle = new Users();
			ekle.UserName = userName;
            ekle.SurName = surName;
            ekle.Address = address;
            ekle.Email = email;         
			ekle.Password = Convert.ToInt32(password);       
            ekle.RuleId = ruleId;
			ekle.CreateDate = DateTime.Now;
			//datalar , db deki tabloya atılması için eşitleme yapıldı
			_db.Users.Add(ekle);
			int saveUser = _db.SaveChanges();//ekleme başarılı ise 1 döner

			if (saveUser > 0)
			{


			}
			//var category = _db.Categories.ToList();
			//ViewBag.Category = category;

			return View();
		}
	}
}
	


	