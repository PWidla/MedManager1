using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDataManagementApp.Core.Entities
{
    [Table("User")]
    public class User
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}