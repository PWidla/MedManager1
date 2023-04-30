using Domain.Common;
using MedicalDataManagementApp.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Patient")]
    public class Patient : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MedicalHistory { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<MedicalRecord>? MedicalRecords { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
    }
}
