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

        public string Comments { get; set; }  

        //Navigation Properties
        public Employee Employee { get; set; } 
        public User GeneratedByUser { get; set; } 
    }
}
