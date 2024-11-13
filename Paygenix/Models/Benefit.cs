﻿using System.ComponentModel.DataAnnotations;

namespace Paygenix.Models
{
    public class Benefit
    {
            [Key]
            public int BenefitID { get; set; }  // Primary Key

            [Required]
            [MaxLength(50)]
            public string BenefitName { get; set; }  

            public string Description { get; set; }  
            public string EligibilityCriteria { get; set; } 

    }
}