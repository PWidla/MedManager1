using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Appointment")]
    public class Appointment : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}