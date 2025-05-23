﻿using System.ComponentModel.DataAnnotations;

namespace WorkifyApp.ViewModel.WorkItem
{
    public class EditWorkItemViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
