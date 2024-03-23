using Microsoft.AspNetCore.Mvc;
using TelefonSatis.Database.IRepository;

namespace TelefonSatis.WEB_UI.Controllers
{
    public class RulesController : Controller
    {

        private readonly IRulesRepository _rulesRepository;

        public RulesController( IRulesRepository rulesRepository)
        {
                _rulesRepository = rulesRepository;
        }


        public IActionResult RulesIndex()
        {
            var list= _rulesRepository.GetAll();
            return View(list);
        }
    }
}
