using System;
using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Members
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only letters are allowed.")]
        [Display (Name = "First Name")]
        [StringLength(20, ErrorMessage = "Please enter your first name using 20 characters or less.")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Please enter your last name using 20 characters or less.")]
        public string? LastName { get; set; }

        [StringLength(50, ErrorMessage = "Please enter your last name using 50 characters or less.")]
        public string? Email { get; set; }

        
        [StringLength(11, ErrorMessage = "Cell phone number has a maximum of 11 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed.")]
        [Display(Name = "Phone Number")]
        public string? Cell { get; set; }

        public ICollection<MoodEntry> MoodEntrys { get; set; } = default!;
    }
}
