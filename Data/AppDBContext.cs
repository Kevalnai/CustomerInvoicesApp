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
    }
}
