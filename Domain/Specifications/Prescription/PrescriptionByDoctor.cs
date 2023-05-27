using Application.Specification;

namespace Domain.Specifications.Prescription
{
    public class PrescriptionByDoctor : BaseSpecification<Entities.Prescription>
    {
        public PrescriptionByDoctor(int doctorId) : base(prescription => prescription.DoctorId == doctorId)
        {
            AddInclude(prescription => prescription.Doctor);
            AddInclude(prescription => prescription.Patient);
        }
    }
}
