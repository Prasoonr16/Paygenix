using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class EmployeeBenefit
    {
        [Key]
        public int EmployeeBenefitID { get; set; }  // Primary Key

        [Required]
        public int EmployeeID { get; set; }  // Foreign Key to Employee

        [Required]
        public int BenefitID { get; set; }  // Foreign Key to Benefit

        public DateTime EnrolledDate { get; set; }  

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }  // Navigation property to Employee

        [ForeignKey("BenefitID")]
        public Benefit Benefit { get; set; }  // Navigation property to Benefit
    }
}
