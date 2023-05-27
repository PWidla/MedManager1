using Application.Specification;

namespace Domain.Specifications.Prescription
{
    public class PrescriptionByPatient : BaseSpecification<Entities.Prescription>
    {
        public PrescriptionByPatient(int patientId) : base(prescription => prescription.PatientId == patientId)
        {
            AddInclude(prescription => prescription.Doctor);
            AddInclude(prescription => prescription.Patient);
        }
    }
}
