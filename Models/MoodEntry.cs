using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class MoodEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column("Entry Date")]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; } = DateTime.Today;

        [Required]
        [StringLength(10, ErrorMessage = "Please enter your last name using 10 characters or less.")]
        public string Mood { get; set; }

        [Required]
        public string Notes { get; set; }

        // Foreign Key to User
        [Display(Name = "Member Id")]
        [Range(1,100)]
        public int MembersId { get; set; }
        public Members? Members { get; set;}
    }

}
