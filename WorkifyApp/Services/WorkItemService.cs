using Microsoft.EntityFrameworkCore;
using WorkifyApp.Constants;
using WorkifyApp.Data;
using WorkifyApp.Models;
using WorkifyApp.Services.Interfaces;
using WorkifyApp.ViewModel.WorkItem;

namespace WorkifyApp.Services
{
    public class WorkItemService : IWorkItemService
    {
        private readonly ApplicationDbContext _db;

        public WorkItemService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<WorkItemListViewModel> GetForListPage()
        {
            var workItems = _db.WorkItems.ToList();
            var viewModel = workItems.Select(x => new WorkItemListViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Status = x.Status,
                Title = x.Title
            }).ToList();
            return viewModel;
        }

        public void Create(AddWorkItemViewModel addWorkItemViewModel)
        {
            var workItem = new WorkItem
            {
                Title = addWorkItemViewModel.Title,
                Description = addWorkItemViewModel.Description,
                Status = WorkItemStatus.ToDo
            };
            _db.WorkItems.Add(workItem);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            if (workItem == null)
                throw new KeyNotFoundException();
            _db.WorkItems.Remove(workItem);
            _db.SaveChanges();
        }

        public EditWorkItemViewModel GetForEditPage(int id)
        {
            var workItem = _db.WorkItems.Find(id);
            if (workItem == null)
               throw new KeyNotFoundException();
            var workItemViewModel = new EditWorkItemViewModel
            {
                Id = workItem.Id,
                Description = workItem.Description,
                Status = workItem.Status,
                Title = workItem.Title
            };
            return workItemViewModel;
        }

        public void Update(EditWorkItemViewModel editWorkItemViewModel)
        {
            var workItem = new WorkItem
            {
                Id = editWorkItemViewModel.Id,
                Description = editWorkItemViewModel.Description,
                Status = editWorkItemViewModel.Status,
                Title = editWorkItemViewModel.Title
            };
            _db.WorkItems.Update(workItem);
            _db.SaveChanges();
        }
    }
}
