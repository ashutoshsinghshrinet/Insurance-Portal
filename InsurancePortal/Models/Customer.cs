using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePortal.Models
{
    [Table(name :"Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }                                             //Customer Id Primary Key

        [Required]
        [MaxLength(50, ErrorMessage ="{0} cannot be greater than {1} characters")]
        [MinLength(2,ErrorMessage ="{0} cannot be less than {1} characters")]
        [Display(Name ="Name of Customer")]
        public string CustomerName { get; set; }                                        //Name


        [MinLength(5,ErrorMessage ="{0} cannot be less than {1} characters")]
        [Display(Name ="Customer's Address")]
        public string CustomerAddress { get; set; }                                     //Address

        [Required]
        [MaxLength(10,ErrorMessage ="Invalid Phone")]
        [MinLength(10, ErrorMessage = "Invalid Phone")]
        [Display(Name ="Contact Number")]
        public string ContactNumber { get; set; }                                       //Contac Number
        public ICollection<Order> Orders { get; set; }
    }
}
