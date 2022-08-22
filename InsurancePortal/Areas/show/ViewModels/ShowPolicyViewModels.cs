using InsurancePortal.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InsurancePortal.Areas.Show.ViewModels
{
    public class ShowPolicyViewModels
    {
        [Required(ErrorMessage = "{0} cannot be empty")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }
}
