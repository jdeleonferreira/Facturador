using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace Facturador.Web.Entities
{
    public class Invoice
    {
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; } = 0;

        public List<InvoiceItem> InvoiceItems { get; set; }
        
    }
}
