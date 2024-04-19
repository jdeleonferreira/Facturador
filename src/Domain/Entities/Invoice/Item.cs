using System.Data;
using System;
using Facturador.Domain.Common;

namespace Facturador.Domain.Entities.Invoice
{
    public class Item : BaseAuditableEntity
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
