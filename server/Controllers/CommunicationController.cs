using Microsoft.AspNetCore.Mvc;

namespace FlexibleJobs.Controllers
{
    public class CommunicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
