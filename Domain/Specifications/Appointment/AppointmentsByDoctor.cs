using Application.Specification;

namespace Domain.Specifications.Appointment
{
    public class AppointmentsByDoctor : BaseSpecification<Entities.Appointment>
    {
        public AppointmentsByDoctor(int doctorId) : base(appointment => appointment.DoctorId == doctorId)
        {
            AddInclude(appointment => appointment.Doctor);
            AddInclude(appointment => appointment.Patient);
        }
    }
}
