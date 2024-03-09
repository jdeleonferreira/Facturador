namespace Facturador.Models
{
    public class InvoiceItemsList
    {
        public int ItemRow { get; set; }
        public Item Item { get; set; }
        public float Quantity { get; set; }
        public decimal LineTotal { get; set; }


        public decimal ValueListItems(float Quantity  )
        {
            decimal LineTotal = (decimal) Quantity *  Item.UnitPrice;
            return LineTotal;
        }
    }
}
