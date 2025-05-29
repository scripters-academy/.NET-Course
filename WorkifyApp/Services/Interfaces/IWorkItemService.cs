using WorkifyApp.ViewModel.WorkItem;

namespace WorkifyApp.Services.Interfaces
{
    public interface IWorkItemService
    {
        List<WorkItemListViewModel> GetForListPage();
        void Create(AddWorkItemViewModel addWorkItemViewModel);
        EditWorkItemViewModel GetForEditPage(int id);
        void Update(EditWorkItemViewModel editWorkItemViewModel);
        void Delete(int id);
    }
}
