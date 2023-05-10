using Domain.Common;
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
        public MedicalRecord? MedicalRecord { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
    }
}
