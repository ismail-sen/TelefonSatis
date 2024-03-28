using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.IRepository;
using TelefonSatis.WEB_UI.Models;

namespace TelefonSatis.WEB_UI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository _productRepository;
       
       
        public CartController(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }
        private  object Session;

        //public IActionResult Index()
        //{
        //    return View(GetCart);
        //}
        //public IActionResult AddToCart(int ProductsId)
        //{
        //    //var product = db.Products.FirstOrDefault(i => i.ProductId == ProductsId);
        //    var product = _productRepository.GetById(ProductsId);
        //    if (product != null)
        //    {
        //        //GetCart().AddProduct(product+1);
        //        //GetCart().AddProduct(product+1);
        //    }
        //    return RedirectToAction("Index");
        //}
        //public IActionResult RemoveFromCart(int ProductsId)
        //{
        //    var product = db.Products.FirstOrDefault(i => i.ProductId == ProductsId);
        //    if (product != null)
        //    {
        //        GetCart().DeleteProduct(product);
        //    }
        //    return RedirectToAction("Index");
        //}
        //public Cart GetCart()
        //{
        //    var cart = Session["Cart"] as Cart;
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}     
    }
}
