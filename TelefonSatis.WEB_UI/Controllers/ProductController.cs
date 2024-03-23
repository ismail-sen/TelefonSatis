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
            ViewBag.Category = _categoryRepository.GetAll();
            return View(_productRepository.GetAll());
        }
    }
}
