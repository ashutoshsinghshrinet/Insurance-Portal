using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePortal.Models
{
    [Table(name:"Contacts")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QueryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Invalid Phone")]
        [MinLength(10, ErrorMessage = "Invalid Phone")]
        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
