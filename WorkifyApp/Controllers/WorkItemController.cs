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
            var viewModel = workItems.Select(x => new WorkItemListViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Status = x.Status,
                Title = x.Title
            }).ToList();
            return View(viewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddWorkItemViewModel workItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var workItem = new WorkItem
                {
                    Title = workItemViewModel.Title,
                    Description = workItemViewModel.Description,
                    Status = WorkItemStatus.ToDo
                };
                _db.WorkItems.Add(workItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workItemViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            if (workItem == null)
                return NotFound();
            var workItemViewModel = new EditWorkItemViewModel
            {
                Id = workItem.Id,
                Description = workItem.Description,
                Status = workItem.Status,
                Title = workItem.Title
            };
            return View(workItemViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditWorkItemViewModel workItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var workItem = new WorkItem
                {
                    Id = workItemViewModel.Id,
                    Description = workItemViewModel.Description,
                    Status = workItemViewModel.Status,
                    Title = workItemViewModel.Title
                };
                _db.WorkItems.Update(workItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workItemViewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            _db.WorkItems.Remove(workItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
