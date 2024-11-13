using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class Employee
    {
            [Key]
            public int EmployeeID { get; set; }  // Primary Key

            [Required]
            [MaxLength(50)]
            public string FirstName { get; set; }  

            [Required]
            [MaxLength(50)]
            public string LastName { get; set; }  

            [Required]
            [MaxLength(100)]
            public string Email { get; set; }  

            [MaxLength(15)]
            public string Phone { get; set; }  

            [MaxLength(50)]
            public string Position { get; set; } 

            [MaxLength(50)]
            public string Department { get; set; } 

            public DateTime HireDate { get; set; } 

            public int? UserID { get; set; }  // Foreign Key to User 

            [ForeignKey("UserID")]
           
            public User User { get; set; }  // Navigation property to User

    }
}
