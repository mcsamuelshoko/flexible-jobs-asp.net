using Microsoft.AspNetCore.Mvc;

namespace FlexibleJobs.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
