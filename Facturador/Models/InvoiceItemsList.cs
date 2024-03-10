namespace Facturador.Models
{
    public class InvoiceItemsList
    {
        public int ItemRow { get; set; }
        public Item Item { get; set; }
        public float Quantity { get; set; }
        //TODO: Check set to be private
        public decimal LineTotal { get; set; }


        //TODO: Change to void.
        //TODO: Change name to CalculateLineTotal
        public decimal ValueListItems(float Quantity  )
        {
            decimal LineTotal = (decimal) Quantity *  Item.UnitPrice;
            return LineTotal;
        }
    }
}
