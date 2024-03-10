namespace Facturador.Models
{
    public class InvoiceItemsList
    {
        public int ItemRow { get; set; }
        public Item Item { get; set; }
        public float Quantity { get; set; }

        //TODO: Check set to be private
        public decimal LineTotal { get; set; }


  
        public void CalculateLineTotal()
        {
            LineTotal =  Convert.ToDecimal(Quantity) *  Item.UnitPrice;
        }
    }
}
