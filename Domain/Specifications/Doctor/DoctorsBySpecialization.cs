using Application.Specification;

namespace Domain.Specifications.Doctor
{
    public class DoctorsBySpecialization : BaseSpecification<Entities.Doctor>
    {
        public DoctorsBySpecialization(Specialization specialization) : base(doctor => doctor.Specialization == specialization)
        {
            AddInclude(doctor => doctor.Appointments);
            AddInclude(doctor => doctor.Prescriptions);
        }
    }
}
