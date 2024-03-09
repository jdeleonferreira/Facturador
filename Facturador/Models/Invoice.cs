namespace Facturador.Models
{
    public class Invoice
    {

        #region Company Data
        public string CompanyName { get; set; }
        public string TaxNumbner { get; set; } //Nit
        public string ContactNumnber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        #endregion 

        public string InvoiceNumber { get; set; }

        #region Customer Data
        public string CustomerName { get; set; }
        public string TaxationCustomerNumbner { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        #endregion

        public DateTime CreationDate { get; set; }
      
        public List<InvoiceItemsList> Items { get; set; }
        public string Notes { get; set; }
        public decimal Total { get; set; }


        //Logic of invoice 


        //Region total Data Final
        public decimal ValueFinalInvoice(decimal total)
        {
            decimal retencionMonto = total * (decimal) 0.025; 
            decimal ivaMonto = total * (decimal)0.19;  

            decimal finalValue = total + retencionMonto + ivaMonto;
            return finalValue;
        }


       





    }
}
