using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation Property (Polikliniğin Doktorları)
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
