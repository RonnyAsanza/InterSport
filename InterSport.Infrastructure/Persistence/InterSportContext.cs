using InterSport.Domain.Entities;
using System.Data.Entity;

namespace InterSport.Infrastructure.Persistence
{
    public partial class InterSportContext : DbContext
    {
        public InterSportContext() : base("InterSport")
        {

        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoicesDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
