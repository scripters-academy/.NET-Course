using Microsoft.AspNetCore.Mvc;
using WorkifyApp.Constants;
using WorkifyApp.Data;
using WorkifyApp.Models;
using WorkifyApp.ViewModel.WorkItem;

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
            var workItemViewModel = workItems.Select(x => new WorkItemListViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Status = x.Status,
                Title = x.Title
            }).ToList();
            return View(workItemViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddWorkItemViewModel addWorkItemViewModel)
        {   
            if (ModelState.IsValid)
            {
                var workItem = new WorkItem
                {
                    Title = addWorkItemViewModel.Title,
                    Description = addWorkItemViewModel.Description,
                    Status = WorkItemStatus.ToDo
                };
                _db.WorkItems.Add(workItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addWorkItemViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            if (workItem == null)
                return NotFound();
            var editWorkItemViewModel = new EditWorkItemViewModel
            {
                Id = workItem.Id,
                Description = workItem.Description,
                Status = workItem.Status,
                Title = workItem.Title
            };
            return View(editWorkItemViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditWorkItemViewModel editWorkItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var workItem = new WorkItem
                {
                    Id = editWorkItemViewModel.Id,
                    Description = editWorkItemViewModel.Description,
                    Title = editWorkItemViewModel.Title,
                    Status = editWorkItemViewModel.Status
                };
                _db.WorkItems.Update(workItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editWorkItemViewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            if (workItem == null)
                return NotFound();
            _db.WorkItems.Remove(workItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
