using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class ComplainceReport
    {
        [Key]
        public int ReportID { get; set; }  // Primary Key

        public DateTime ReportDate { get; set; }  
        public int? EmployeeID { get; set; }  // Foreign Key to Employee

        [MaxLength(50)]
        public DateTime PayrollIssued { get; set; }  

        [MaxLength(50)]
        public string ComplianceStatus { get; set; }

       
        public string IssuesFound { get; set; } 
        
        
        public string ResolvedStatus { get; set; }  

        public int GeneratedBy { get; set; }  // Foreign Key to User who generated the report

        public string Comments { get; set; }  

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }  // Navigation property to Employee

        [ForeignKey("GeneratedBy")]
        public User User { get; set; }  // Navigation property to User who generated the report
    }
}
