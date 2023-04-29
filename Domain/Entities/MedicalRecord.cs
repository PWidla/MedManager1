using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("MedicalRecord")]
    public class MedicalRecord : BaseEntity
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public string MedicalHistory { get; set; }
    }
}
