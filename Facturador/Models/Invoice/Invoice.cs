using Facturador.Models.Taxes;
using Facturador.Models.Customer;

namespace Facturador.Models.Invoice
{
    public class Invoice
    {
        private readonly Taxes.Taxes _Taxes;

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
        public Customer.Customer Customer { get; set; }
        #endregion

        public DateTime CreationDate { get; set; }

        public List<InvoiceItemsList> Items { get; set; }
        public string Notes { get; set; }
        public List<Tax> Taxes { get; set; }
        //TODO: Revisar adelante. Set should be private.
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public Invoice(Taxes.Taxes taxes)
        {
            _Taxes = taxes;
        }

        //Region total Data Final  
        //TODO: Add functionality to get all tax info from external place. 5   

        /// <summary>
        /// Calculate total invoice and taxes for items globally.
        /// </summary>
        public void CalculateTotalInvoice()
        {
            decimal totalItems = 0;
            foreach (InvoiceItemsList item in Items)
            {
                item.CalculateLineTotal();
                totalItems += item.LineTotal;
            }

            var iva = _Taxes.CalculateTaxes(TaxesList.IVA, totalItems);
            Subtotal = totalItems;
            Total = Subtotal + iva;
        }
    }
}
