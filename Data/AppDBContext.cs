using CustomerInvoicesApp.Models;
using Microsoft.EntityFrameworkCore;
namespace CustomerInvoicesApp.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<PaymentTerms> PaymentTerms { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Customer)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<Invoice>()
           .HasMany(i => i.InvoiceLineItems)
           .WithOne(li => li.Invoice)
           .HasForeignKey(li => li.InvoiceId);
        }
    }
}
