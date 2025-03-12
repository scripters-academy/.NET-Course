using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WorkifyApp.Models;

namespace WorkifyApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            throw new Exception(Activity.Current?.Id ?? HttpContext.TraceIdentifier);
            //return View();
        }

        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(model);
        }
    }
}
