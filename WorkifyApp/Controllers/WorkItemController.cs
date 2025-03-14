using Microsoft.AspNetCore.Mvc;

namespace WorkifyApp.Controllers
{
    public class WorkItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
