using System.ComponentModel.DataAnnotations;

namespace CustomerInvoicesApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Address 1 is required.")]
        public string Address1 { get; set; }

        public string? Address2 { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "Province/State is required.")]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "Province/State must be a 2-letter code.")]
        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "Zip/Postal Code is required.")]
        [RegularExpression(@"^(\d{5}(-\d{4})?|[A-Z]\d[A-Z] ?\d[A-Z]\d)$", ErrorMessage = "Invalid Zip/Postal Code format.")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Phone number must be in a valid US or Canadian format.")]
        public string? Phone { get; set; }

        public string? ContactLastName { get; set; }

        public string? ContactFirstName { get; set; }

 
        public string? ContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Invoice> Invoices { get; set; }
    }
}
