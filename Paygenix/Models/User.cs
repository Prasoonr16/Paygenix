using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }  // Primary Key

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }  

        [Required]
        [MaxLength(20)]
        public string PasswordHash { get; set; }

        [Required]
        public int RoleID { get; set; }  // Foreign Key to Role

        public DateTime CreatedDate { get; set; } 
        public DateTime? LastLogin { get; set; }  

        [ForeignKey("RoleID")]
        public Role Role { get; set; }  // Navigation property to Role
    }
}
