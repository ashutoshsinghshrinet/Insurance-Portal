using System.ComponentModel.DataAnnotations;



// Model Class for implementing Role Management
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
