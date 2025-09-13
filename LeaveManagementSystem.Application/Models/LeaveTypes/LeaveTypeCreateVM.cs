﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Application.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required (ErrorMessage = "Name is required.")]
        [Length(4, 150, ErrorMessage= "Name must be between 4 and 150 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Number of days is required.")]
        [Range(1, 90, ErrorMessage = "Number of days must be between 1 and 90.")]
        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
