using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCCORE_NexusMart.Models
{
    public class NEXDBContext : IdentityDbContext<IdentityUser>
    {
        public NEXDBContext(DbContextOptions<NEXDBContext> options) : base(options)
        {
        }

        public DbSet<Admin> Tbl_Admin { get; set; }
        public DbSet<Customer> Tbl_Customer { get; set; }
        public DbSet<Product> Tbl_Product { get; set; }
        public DbSet<Category> Tbl_Category { get; set; }
        public DbSet<Cart> Tbl_Cart { get; set; }
        public DbSet<Feedback> Tbl_Feedback { get; set; }
        public DbSet<FAQs> Tbl_FAQs { get; set; }

    }

}
