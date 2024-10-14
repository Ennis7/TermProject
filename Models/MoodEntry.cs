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
        public DateTime EntryDate { get; set; } = DateTime.Today;
        public string Mood { get; set; }
        public string Notes { get; set; }

        // Foreign Key to User
        public int MembersId { get; set; }
        public Members? Members { get; set;}
    }

}
