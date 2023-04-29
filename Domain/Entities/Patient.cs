using MedicalDataManagementApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Patient")]
    public class Patient : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MedicalHistory { get; set; }
    }
}
