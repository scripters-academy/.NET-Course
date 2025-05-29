using Microsoft.AspNetCore.Mvc;
using WorkifyApp.Constants;
using WorkifyApp.Data;
using WorkifyApp.Models;
using WorkifyApp.Services.Interfaces;
using WorkifyApp.ViewModel.WorkItem;

namespace WorkifyApp.Controllers
{
    public class WorkItemController : Controller
    {
        private readonly IWorkItemService _workItemService;
        public WorkItemController( IWorkItemService workItemService)
        {
            _workItemService = workItemService;
        }

        public IActionResult Index()
        {
            return View(_workItemService.GetForListPage());
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
                _workItemService.Create(workItemViewModel);
                return RedirectToAction("Index");
            }
            return View(workItemViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                return View(_workItemService.GetForEditPage(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(EditWorkItemViewModel workItemViewModel)
        {
            if (ModelState.IsValid)
            {
                _workItemService.Update(workItemViewModel);
                return RedirectToAction("Index");
            }
            return View(workItemViewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _workItemService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
