using Microsoft.AspNetCore.Mvc;

namespace TelefonSatis.WEB_UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductIndex()
        {
            return View();
        }
    }
}
