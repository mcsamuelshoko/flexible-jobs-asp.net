using Microsoft.AspNetCore.Mvc;

namespace FlexibleJobs.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
