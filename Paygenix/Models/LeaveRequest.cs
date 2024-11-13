using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class LeaveRequest
    {
            [Key]
            public int LeaveRequestID { get; set; }  // Primary Key

            [Required]
            public int EmployeeID { get; set; }  // Foreign Key to Employee

            [Required]
            public DateTime StartDate { get; set; }  

            [Required]
            public DateTime EndDate { get; set; }  

            [Required]
            [MaxLength(50)]
            public string LeaveType { get; set; }  

            [Required]
            [MaxLength(50)]
            public string Status { get; set; }  

            public DateTime RequestDate { get; set; }  
            public DateTime? ApprovalDate { get; set; }

            [ForeignKey("EmployeeID")]
            public Employee Employee { get; set; }  // Navigation property to Employee
        }

}
