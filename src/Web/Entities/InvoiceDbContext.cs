using Microsoft.EntityFrameworkCore;

namespace Facturador.Web.Entities
{
    public class InvoiceDbContext: DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options):base(options)
        {}

        public DbSet<Invoice> Invoices { get; set;}
        public DbSet<InvoiceItem> InvoiceItems { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set;}
    }
}
