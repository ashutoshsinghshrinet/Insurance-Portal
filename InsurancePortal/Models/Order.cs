using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//Model Class for viewing and accessing for Applied Policies  



namespace InsurancePortal.Models
{
    [Table(name:"Orders")]
    public class Order
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Order ID")]
        public int OrderID { get; set; }


        [Display(Name ="Enter Email")]
        public string UserName { get; set; }

        [Display(Name ="Policy ID")]
        public int PolicyId { get; set; }
        [ForeignKey(nameof(Order.PolicyId))]
        public Policy Policy { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [Display(Name ="Date/Time")]
        public DateTime OrderDateTime { get ; set; }


        
        
    }
}
