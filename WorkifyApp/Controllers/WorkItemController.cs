using Microsoft.AspNetCore.Mvc;
using WorkifyApp.Data;
using WorkifyApp.Models;

namespace WorkifyApp.Controllers
{
    public class WorkItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WorkItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var workItems = _db.WorkItems.ToList();
            return View(workItems);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(WorkItem workItem)
        {
            _db.WorkItems.Add(workItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            return View(workItem);
        }
        [HttpPost]
        public IActionResult Edit(WorkItem workItem)
        {
            _db.WorkItems.Update(workItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
