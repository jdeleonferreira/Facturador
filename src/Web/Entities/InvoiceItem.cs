using System;
using System.Collections.Generic;

namespace Facturador.Web.Entities;

public partial class InvoiceItem
{
    public int InvoiceId { get; set; }

    public string ItemDescription { get; set; } = null!;

    public string ItemCode { get; set; } = null!;

    public string UnitPrice { get; set; } = null!;

    public byte Row { get; set; }

    public double Quantity { get; set; }

    public int UnitOfMeasurement { get; set; }

    public decimal LineTotal { get; set; }

    public string TaxDescription { get; set; } = null!;

    public decimal TaxTotal { get; set; }

    public int Id { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual UnitOfMeasurement UnitOfMeasurementNavigation { get; set; } = null!;
}
