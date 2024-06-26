﻿using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.TelefonSatisDatabase;
using TelefonSatis.Repository;

namespace TelefonSatis.Web.Controllers
{
	public class Products_Controller : BaseController1
	{
		//Linq, Katmanlı mimariler, UnitOf Work, Repository Design pattern olmadan bu sayfa test amaçlı (bahsedilen yapılar olmadan nasıl proje kullanılır örneği için) açıldı
		TelefonSatisDB _db;
		public Products_Controller(TelefonSatisDB db)//DI
		{
			_db = db;
		}

		public IActionResult ProductIndex()
		{
			var productList = _db.Products.ToList();//Bütün Products tablosundaki dataları ToList() ile listelemiş olduk
			var category=_db.Categories.ToList();
			ViewBag .Category = category;

			var userInfo=_db.Users.ToList();
			ViewBag.User = userInfo;
			return View(productList);
		}

		[HttpGet]
		public IActionResult AddProduct()
		{

			var product = _db.Products.ToList();
			ViewBag.Products = product;
			ViewBag.Category = _db.Categories.ToList();
			// ViewData["Category"] = category;
			//TempData["Category"] = category;//daha büyük datalar için kullanılır

			return View();
		}


		[HttpPost]
		public IActionResult AddProduct(string productName, string price, string stock, int categoryId)
		{

			Products ekle = new Products();
			ekle.ProductName = productName;
			ekle.Price = Convert.ToDecimal(price);
			ekle.Stock = Convert.ToInt32(stock);
			ekle.CategoryId = categoryId;
			ekle.CreateDate = DateTime.Now;
			ekle.UserId = UserId;
			//datalar , db deki tabloya atılması için eşitleme yapıldı
			_db.Products.Add(ekle);
			int saveProduct = _db.SaveChanges();//ekleme başarılı ise 1 döner

			if (saveProduct > 0)
			{
				ViewBag.mesaj = "<b style='color:green'>" + productName + " ürünü başarılı bir şekilde eklendi</b>";
			}
			else
			{
				ViewBag.mesaj = "<b style='color:red'>" + productName + " ürünü eklenemedi</b>";

			}
			var category = _db.Categories.ToList();
			ViewBag.Category = category;

			return View();
		}


		//get
		public ActionResult UpdateProduct(int Id)
		{
			//Linq ile select *from Products where ProductsId=1000 kodun aynısı aşağıdaki gibi olacaktır
			var getProductFind = _db.Products.Where(k => k.ProductsId == Id).FirstOrDefault();
			//Where
			//FirstOrDefault=> eşleşen ilk değeri getirir
			//EF- Linq ile kodlama 8-9 kod yapısı var , nettten bakılabilir
			try
			{
				ViewBag.categoryName = _db.Categories.Where(k => k.CategoriesId == getProductFind.CategoryId).FirstOrDefault().CategoryName;

			}
			catch (Exception)
			{
			}

			//yukardaki linq , sql karşılığı select CategoryName from Categories where CategoriesId=2 şeklindedir

			ViewBag.Category = _db.Categories.ToList();
			return View(getProductFind);
		}

		[HttpPost]
		public ActionResult UpdateProduct(int ProductsId, string productName, string price, string stock, int categoryId)
		{
			try
			{
				var getProduct = _db.Products.Where(k => k.ProductsId == ProductsId).FirstOrDefault();
				//DB'deki isim = güncellenmek istenen isim
				getProduct.ProductName = productName;
				getProduct.Price = Convert.ToDecimal(price);
				getProduct.Stock = Convert.ToInt32(stock);
				getProduct.CategoryId = categoryId;

				int update = _db.SaveChanges();


				ViewBag.Category = _db.Categories.ToList();

				if (update > 0)
				{
					//işlem başarılı
					ViewBag.mesaj = "<b style='color:green'>ürün başarılı bir şekilde güncellendi</b>";
					return View(getProduct);
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
		public ActionResult DeleteProduct(int Id)
		{
			try
			{
				var getProduct = _db.Products.Where(k => k.ProductsId == Id).FirstOrDefault();
				if (getProduct != null)
				{
					return View(getProduct);
				}
			}
			catch (Exception)
			{
			}

			return View();
		}

		[ActionName("DeleteProduct")]
		[HttpPost]
		public ActionResult ProductRemove (int ProductId)
		{
			try
			{
				var deleteProduct = _db.Products.Where(k => k.ProductsId == ProductId).FirstOrDefault();
				if (deleteProduct != null)
				{
					_db.Products.Remove(deleteProduct);
					int removeSave =_db.SaveChanges();
					if(removeSave > 0)
					{
						//ViewBag.mesajSil = "Başarılı şekilde silindi.";
						ViewBag.mesaj = "<b style='color:green'>Başarılı şekilde silindi.</b>";
						
						//return View(deleteProduct);
						return RedirectToAction("ProductIndex");
					}
				}

			}
			catch (Exception)
			{
			}
			return View();
		}

    }
}

