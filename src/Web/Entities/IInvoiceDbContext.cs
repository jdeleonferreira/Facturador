using Microsoft.EntityFrameworkCore;

namespace Facturador.Web.Entities
{
    public interface IInvoiceDbContext
    {

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UnitOfMeasurement> Units { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges(CancellationToken cancellationToken);
    }
}

