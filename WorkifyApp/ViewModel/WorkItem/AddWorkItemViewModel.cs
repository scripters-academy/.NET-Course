﻿using System.ComponentModel.DataAnnotations;

namespace WorkifyApp.ViewModel.WorkItem
{
    public class AddWorkItemViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
