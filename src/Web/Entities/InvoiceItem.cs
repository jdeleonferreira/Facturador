namespace Facturador.Web.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCode { get; set; }
        public string UnitPrice { get; set; }
        public byte Row { get; set; }
        public float Quantity { get; set; }
        public int UnitOfMeasurement { get; set; }
        public decimal LineTotal { get; set; }
        public string TaxDescription { get; set; }
        public string TaxTotal { get; set; }
        
    }
}
