using CustomerInvoicesApp.Data;
using CustomerInvoicesApp.Models;
using CustomerInvoicesAppLibrary.Models;
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
                selectedInvoice.PaymentTotal = selectedInvoice.InvoiceLineItems.Sum(li => li.Amount);
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
            // Populate a new Invoice object with default values
            var invoice = new Invoice
            {
                CustomerId = customerId,
                InvoiceDate = DateTime.UtcNow
            };

            // Pass PaymentTerms to the ViewBag for dropdown population
            ViewBag.PaymentTerms = _dbContext.PaymentTerms.ToList();

            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvoice(Invoice invoice)
        {
            // Validate that the PaymentTermsId exists in the database
            var paymentTerms = await _dbContext.PaymentTerms
                .FirstOrDefaultAsync(pt => pt.PaymentTermsId == invoice.PaymentTermsId);

            if (paymentTerms == null)
            {
                ModelState.AddModelError("PaymentTermsId", "Invalid payment terms selected.");
            }

            // Check if the model is valid before saving
            if (!ModelState.IsValid)
            {
                // Repopulate PaymentTerms for redisplaying the form on error
                ViewBag.PaymentTerms = _dbContext.PaymentTerms.ToList();
                return View(invoice);
            }

            // Add the invoice to the database
            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();

            // Redirect to the index page with the customerId
            return RedirectToAction(nameof(Index), new { customerId = invoice.CustomerId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInvoiceLineItem(InvoiceLineItem invoiceLineItem)
        {
            if (!ModelState.IsValid)
            {
                // Save the new invoice line item to the database
                _dbContext.InvoiceLineItems.Add(invoiceLineItem);
                await _dbContext.SaveChangesAsync();

                // Recalculate PaymentTotal for the invoice
                var invoice = await _dbContext.Invoices
                    .Include(i => i.InvoiceLineItems)
                    .FirstOrDefaultAsync(i => i.InvoiceId == invoiceLineItem.InvoiceId);

                if (invoice != null)
                {
                    invoice.PaymentTotal = invoice.InvoiceLineItems.Sum(li => li.Amount);
                    await _dbContext.SaveChangesAsync();
                }

                // Redirect to the index page to show the updated invoice
                return RedirectToAction(nameof(Index), new { customerId = invoiceLineItem.Invoice.CustomerId, selectedInvoiceId = invoiceLineItem.InvoiceId });
            }

            return View(invoiceLineItem); // If model state is not valid, return the form to show validation errors
        }
    }
}
