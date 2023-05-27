using Application.Specification;

namespace Domain.Specifications.Prescription
{
    public class PrescriptionsByDoctor : BaseSpecification<Entities.Prescription>
    {
        public PrescriptionsByDoctor(int doctorId) : base(prescription => prescription.DoctorId == doctorId)
        {
            AddInclude(prescription => prescription.Doctor);
            AddInclude(prescription => prescription.Patient);
        }
    }
}
