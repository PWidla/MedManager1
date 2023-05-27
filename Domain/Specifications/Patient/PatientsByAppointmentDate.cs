using Application.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.Patient
{
    public class PatientsByAppointmentDate : BaseSpecification<Entities.Patient>
    {
        public PatientsByAppointmentDate(DateTime appointmentDate)
            : base(d => d.Appointments != null && d.Appointments.Any(a => a.Date.Date == appointmentDate.Date))
        {
            AddInclude(d => d.Appointments);
        }
    }
}
