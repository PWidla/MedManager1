using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Doctor")]
    public class Doctor : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Prescription>? Prescriptions { get; set; }
    }
}
