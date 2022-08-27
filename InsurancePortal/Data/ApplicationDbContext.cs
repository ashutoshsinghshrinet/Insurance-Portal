using Microsoft.EntityFrameworkCore;
using InsurancePortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InsurancePortal.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Pollicies { get; set; }
        public DbSet<PolicyCategory> PolicyCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
