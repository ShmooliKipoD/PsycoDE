using System;
using System.ComponentModel.DataAnnotations;

namespace blog.ViewModels
{
    public class TripViewModel
    {
        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;   
    }
}