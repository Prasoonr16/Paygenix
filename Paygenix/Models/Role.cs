using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }  // Primary Key

        [Required]
        public string RoleName { get; set; }  
    }
}
