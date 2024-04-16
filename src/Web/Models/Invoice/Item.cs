using System.Data;
using System;

namespace Facturador.Models.Invoice
{
    public class Item
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
