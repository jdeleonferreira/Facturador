using Facturador.Domain.Entities.Invoice;

namespace Facturador.Web.Entities;
public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; } 

    public string? TaxNumber { get; set; } = null;

    public string? ContactNumber { get; set; } = null; 

    public string? Address { get; set; } = null;

    public int City { get; set; }

    public string? Email { get; set; } = null;

    public string? PasswordCustomer { get; set; } = null; 

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
