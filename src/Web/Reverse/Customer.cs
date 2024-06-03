using System;
using System.Collections.Generic;

namespace Facturador.Web.Reverse;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? TaxNumber { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int City { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
