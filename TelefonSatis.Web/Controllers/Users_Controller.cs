using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Users_Controller : BaseController1
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
				ViewBag.mesaj = "<b style='color:green'>" + userName + " ürünü başarılı bir şekilde eklendi</b>";
			}
			else
			{
				ViewBag.mesaj = "<b style='color:red'>" + userName + " ürünü eklenemedi</b>";

			}
			//var category = _db.Categories.ToList();
			//ViewBag.Category = category;

			return View();
		}
		//get
		public ActionResult UpdateUser(int Id)
		{
			//Linq ile select *from Products where ProductsId=1000 kodun aynısı aşağıdaki gibi olacaktır
			var getUserFind = _db.Users.Where(k => k.UsersId == Id).FirstOrDefault();
			//Where
			//FirstOrDefault=> eşleşen ilk değeri getirir
			//EF- Linq ile kodlama 8-9 kod yapısı var , nettten bakılabilir
			try
			{
				ViewBag.userName = _db.Users.Where(k => k.UsersId == getUserFind.UsersId).FirstOrDefault().UserName;

			}
			catch (Exception)
			{
			}

			//yukardaki linq , sql karşılığı select CategoryName from Categories where CategoriesId=2 şeklindedir

			ViewBag.User = _db.Users.ToList();
			return View(getUserFind);
		}

		[HttpPost]
		public ActionResult UpdateUser(int UsersId, string userName, string surName, string address, string email, string password, int ruleId)
		{
			try
			{
				var getUser = _db.Users.Where(k => k.UsersId == UsersId).FirstOrDefault();
				//DB'deki isim = güncellenmek istenen isim
				getUser.UserName = userName;
				getUser.SurName = surName;
				getUser.Address = address;
				getUser.Email = email;
				getUser.Password = Convert.ToInt32(password);
				getUser.RuleId = ruleId;

				int update = _db.SaveChanges();


				ViewBag.User = _db.Users.ToList();

				if (update > 0)
				{
					//işlem başarılı
					ViewBag.mesaj = "<b style='color:green'>ürün başarılı bir şekilde güncellendi</b>";
					return View(getUser);
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
		public ActionResult DeleteUser(int Id)
		{
			try
			{
				var getUser = _db.Users.Where(k => k.UsersId == Id).FirstOrDefault();
				if (getUser != null)
				{
					return View(getUser);
				}
			}
			catch (Exception)
			{

				throw;
			}
			return View();

		}
		[ActionName("DeleteUser")]
		[HttpPost]
		public ActionResult UserRemove(int UserId)
		{
			try
			{
				var deleteUser = _db.Users.Where(k => k.UsersId == UserId).FirstOrDefault();
				if (deleteUser != null)
				{
					_db.Users.Remove(deleteUser);
					int removeSave = _db.SaveChanges();
					if (removeSave > 0)
					{
						ViewBag.mesajSil = "Başarılı şekilde silindi";

						return RedirectToAction("UserIndex");
					}
				}

			}
			catch (Exception)

			{
				throw;
			}

			return View();
		}



		public ActionResult Login()
		{
			if (true)
			{

				UserId = 1;
				return View();
			}
		}
	}
}



