namespace Facturador.Web.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public string Email { get; set; }
    }
}
