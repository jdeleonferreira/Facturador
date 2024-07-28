using System;
using System.Collections.Generic;

namespace Facturador.Web.Entities;

public partial class UnitOfMeasurement
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
