using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

        // Navigation Property (Doktorun Randevuları)
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        public string FullName => $"{Name} {Surname}";
    }
}
