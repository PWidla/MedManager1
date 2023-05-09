using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDataManagementApp.Core.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
    }
}