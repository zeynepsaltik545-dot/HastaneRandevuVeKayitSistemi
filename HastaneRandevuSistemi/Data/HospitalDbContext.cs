using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Data
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Öğrenci projesi için varsayılan olarak (localdb)\MSSQLLocalDB veya .\SQLEXPRESS kullanılabilir.
                // Biz burada LocalDB kullanıyoruz.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HastaneRandevuDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişki tanımlamaları (Data Annotations ile de yapıldı ancak burada da garantiye alıyoruz)
            
            // Branch - Doctor ilişkisi (Bire-Çok)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Branch)
                .WithMany(b => b.Doctors)
                .HasForeignKey(d => d.BranchId);

            // Patient - Appointment ilişkisi (Bire-Çok)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientTc);

            // Doctor - Appointment ilişkisi (Bire-Çok)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
