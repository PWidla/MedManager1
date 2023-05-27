using Application.Specification;

namespace Domain.Specifications.Doctor
{
    public class DoctorsByAppointmentDate : BaseSpecification<Entities.Doctor>
    {
        public DoctorsByAppointmentDate(DateTime appointmentDate)
            : base(d => d.Appointments != null && d.Appointments.Any(a => a.Date.Date == appointmentDate.Date))
        {
            AddInclude(d => d.Appointments);
        }
    }
}
