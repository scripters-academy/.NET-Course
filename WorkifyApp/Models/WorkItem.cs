using System.ComponentModel.DataAnnotations;
using WorkifyApp.Constants;

namespace WorkifyApp.Models
{
    public class WorkItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Status { get; set; } = WorkItemStatus.ToDo;
    }
}
