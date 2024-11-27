using CustomerInvoicesApp.Data;
using CustomerInvoicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


namespace CustomerInvoicesApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDBContext _context;

        public CustomersController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.Where(c => !c.IsDeleted).ToListAsync();

            ViewBag.ShowUndo = TempData["ShowUndo"] as bool? ?? false;
            ViewBag.LastDeletedCustomerId = TempData["LastDeletedCustomerId"];

            return View(customers);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = true;
            await _context.SaveChangesAsync();

            TempData["ShowUndo"] = true;
            TempData["LastDeletedCustomerId"] = customer.CustomerId;

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UndoDelete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = false; // Undo the soft delete
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            ViewBag.FormAction = "AddCustomer";
            return View(new Customer()); // Pass an empty Customer model to the view
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
           
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Course created successfully.";
                return RedirectToAction(nameof(Index));
            
            
        }





      

        [HttpGet]
        public async Task<IActionResult> EditCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id && !c.IsDeleted);
            if (customer == null)
            {
                return NotFound(); // Return 404 if customer does not exist or is deleted
            }
            ViewBag.FormAction = "EditCustomer";
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(Customer customer)
        {
            ModelState.Remove("Invoices");
            
            if (!ModelState.IsValid)
            {
                ViewBag.FormAction = "EditCustomer";
                return View(customer); // Return to the view with validation messages
            }

           
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



        }


        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}

