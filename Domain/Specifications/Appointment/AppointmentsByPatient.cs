using Application.Specification;

namespace Domain.Specifications.Appointment
{
    public class AppointmentsByPatient : BaseSpecification<Entities.Appointment>
    {
        public AppointmentsByPatient(int patientId) : base(appointment => appointment.PatientId == patientId)
        {
            AddInclude(appointment => appointment.Doctor);
            AddInclude(appointment => appointment.Patient);
        }
    }
}
