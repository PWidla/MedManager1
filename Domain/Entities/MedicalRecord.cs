using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("MedicalRecord")]
    public class MedicalRecord : BaseEntity
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string MedicalHistory { get; set; }
    }
}
