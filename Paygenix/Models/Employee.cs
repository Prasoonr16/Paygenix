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

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address.")]
            public string Email { get; set; }  

            [MaxLength(10)]
            [Required(ErrorMessage = "Phone number is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string PhoneNumber { get; set; }  

            [MaxLength(50)]
            public string Position { get; set; } 

            [MaxLength(50)]
            public string Department { get; set; } 

            public DateTime HireDate { get; set; }

    }
}
