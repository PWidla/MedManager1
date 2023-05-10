using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(pr => pr.Patient)
                .HasForeignKey(pr => pr.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(mr => mr.Patient)
                .HasForeignKey<MedicalRecord>(mr => mr.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Prescriptions)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}