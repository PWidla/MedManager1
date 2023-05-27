using Application.Specification;

namespace Domain.Specifications.Appointment
{
    public class AppointmentsByDate : BaseSpecification<Entities.Appointment>
    {
        public AppointmentsByDate(DateTime date) : base(appointment => appointment.Date == date)
        {
            AddInclude(appointment => appointment.Doctor);
            AddInclude(appointment => appointment.Patient);
        }
    }
}
