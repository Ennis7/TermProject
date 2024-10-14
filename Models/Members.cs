using System;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Members
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "First Name")]
        [StringLength(20, ErrorMessage = "Please enter your first name using 20 characters or less.")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Please enter your last name using 20 characters or less.")]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        
        [StringLength(11, ErrorMessage = "Cell phone number has a maximum of 11 numbers")]
        [Display(Name = "Phone Number")]
        public string? Cell { get; set; }

    }
}
