using System.ComponentModel.DataAnnotations;

namespace InsurancePortal.Models
{
    public enum MyIdentityRoleNames
    {
        [Display(Name ="Admin Role")]
        AppAdmin,

        [Display(Name ="User Role")]
        AppUser


    }
}
