using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Patient
    {
        [Key]
        [StringLength(11, MinimumLength = 11)]
        public string TcNo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;

        // Navigation Property (Hastanın Randevuları)
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
