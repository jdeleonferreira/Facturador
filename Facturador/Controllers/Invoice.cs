namespace Facturador.Controllers
{
    public class Invoice
    {
        public string NomnbreEmpresa { get; set;}
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }

        public List<Item> Items { get; set; }
        public string Nota { get; set; }

    }
}
