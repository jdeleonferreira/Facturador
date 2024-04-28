using Facturador.Domain.Common;

namespace Facturador.Domain.Entities.Invoice
{
    public class InvoiceItemsList : BaseAuditableEntity
    {
        public int ItemRow { get; set; }
        public Item Item { get; set; }
        public float Quantity { get; set; }

        //TODO: Check set to be private
        public decimal LineTotal { get; set; }



        public void CalculateLineTotal()
        {
            LineTotal = Convert.ToDecimal(Quantity) * Item.UnitPrice;
        }
    }
}
