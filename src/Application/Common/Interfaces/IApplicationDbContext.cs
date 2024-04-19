using Facturador.Domain.Entities.Invoice;

namespace Facturador.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //DbSet<TodoList> TodoLists { get; }

        DbSet<Invoice> Invoices { get; }
        DbSet<InvoiceItemsList> InvoiceItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
