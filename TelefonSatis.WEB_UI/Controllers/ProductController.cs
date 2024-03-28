using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.IRepository;

namespace TelefonSatis.WEB_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
		private readonly ICategoriesRepository _categoryRepository;


        public ProductController(IProductRepository productRepository,ICategoriesRepository categoriesRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoriesRepository;
                
        }

        public IActionResult ProductIndex()
       {
            #region Session and Cookie

            //Session=> Server da değer turmak için kullanılır
            //Cookie=> Kullanıcı localinde değer tutmak için kullanılır

            HttpContext.Session.SetString("Sepet", "Sepete olmasını istediğiniz değer");//Session core için bu şekilde oluşturulur

            HttpContext.Session.GetString("Sepet");//Çağırma
            //***************************************************
            string userName = "ismail";
            Response.Cookies.Append("username", userName);//Cookie create etmek 
            #endregion

            ViewBag.Category = _categoryRepository.GetAll();
            //         return View(_productRepository.GetAll());
            var sp = _productRepository.ProductListWithCategory();
			return View(sp);
		}

        public IActionResult ProductDetail(int Id)
        {
            var getProduct = _productRepository.GetById(Id);
            return View(getProduct);
        }
    }
}
