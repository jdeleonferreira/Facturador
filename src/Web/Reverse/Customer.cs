using Facturador.Web.Reverse;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; } // Modificado para permitir nulos

    public string? TaxNumber { get; set; } = null;

    public string? ContactNumber { get; set; } = null; // Modificado para permitir nulos

    public string? Address { get; set; } = null; // Modificado para permitir nulos

    public int City { get; set; }

    public string? Email { get; set; } = null;

    public string? PasswordCustomer { get; set; } = null; // Modificado para permitir nulos

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
