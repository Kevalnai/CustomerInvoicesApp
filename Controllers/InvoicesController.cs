using CustomerInvoicesApp.Data;
using CustomerInvoicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoicesApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly AppDBContext _dbContext;

        public InvoicesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int customerId, int? selectedInvoiceId)
        {
            var customer = await _dbContext.Customers
                .Include(c => c.Invoices)
                .ThenInclude(i => i.InvoiceLineItems)
                .Include(c => c.Invoices)
                .ThenInclude(i => i.PaymentTerms)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return NotFound();

            }
            var selectedInvoice = customer.Invoices.FirstOrDefault();
            if (selectedInvoiceId.HasValue)
            {
                selectedInvoice = customer.Invoices.FirstOrDefault(i => i.InvoiceId == selectedInvoiceId.Value);
            }

            var viewModel = new CustomerInvoicesViewModel
            {
                Customer = customer,
                SelectedInvoice = selectedInvoice
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddInvoice(int customerId)
        {
            var invoice = new Invoice
            {
                CustomerId = customerId,
                InvoiceDate = DateTime.UtcNow
            };
            return View(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View(invoice);
            }
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { customerid = invoice.CustomerId });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvoiceLineItem(InvoiceLineItem invoicelineItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index), new { customerId = invoicelineItem.Invoice.CustomerId, selectedInvoiceId = invoicelineItem.InvoiceId });
            }

            _dbContext.InvoiceLineItems.Add(invoicelineItem);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { customerId = invoicelineItem.Invoice.CustomerId, selectedInvoiceId = invoicelineItem.InvoiceId });
        }
    }
}
