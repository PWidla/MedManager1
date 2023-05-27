using Application.Specification;

namespace Domain.Specifications.Prescription
{
    public class PrescriptionsByPatient : BaseSpecification<Entities.Prescription>
    {
        public PrescriptionsByPatient(int patientId) : base(prescription => prescription.PatientId == patientId)
        {
            AddInclude(prescription => prescription.Doctor);
            AddInclude(prescription => prescription.Patient);
        }
    }
}
