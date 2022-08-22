﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePortal.Models
{
    public class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Policy Number")]
        public int PolicyId { get; set; }

        [Required]
        [Display(Name ="Policy Name")]
        public string PolicyName { get; set; }

        [Display(Name = "Image")]
        public string PolicyImageURL { get; set; }

        public int CategoryId { get; set; }
        
        [ForeignKey(nameof(Policy.CategoryId))]
        public PolicyCategory PolicyCategory { get; set; }
    }
}