using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Admin")]
    public class Admin : User
    {
        public string Nickname { get; set; }
    }
}
