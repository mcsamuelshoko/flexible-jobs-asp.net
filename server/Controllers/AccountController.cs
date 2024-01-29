using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
