using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Appointment> Appointments { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<MedicalRecord> MedicalRecords { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<Prescription> Prescriptions { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
