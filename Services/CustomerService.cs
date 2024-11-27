using CustomerInvoicesApp.Data;
using CustomerInvoicesAppLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoicesApp.Services
{
    public class CustomerService
    {
        private readonly AppDBContext _context;

        public CustomerService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}
