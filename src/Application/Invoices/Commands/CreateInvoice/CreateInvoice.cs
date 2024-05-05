using Facturador.Application.Common.Interfaces;
using Facturador.Domain.Entities;
using Facturador.Domain.Entities.Customer;
using Facturador.Domain.Entities.Invoice;
using Facturador.Domain.Entities.Taxes;
//using CleanArchitecture.Domain.Events;

namespace Facturador.Application.Invoices.Commands.CreateInvoice
{

    public record CreateInvoiceCommand : IRequest<int>
    {
        public string CompanyName { get; init; }
        public string TaxNumbner { get; init; } //Nit
        public string ContactNumnber { get; init; }
        public string Address { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string InvoiceNumber { get; init; }
        public Customer Customer { get; init; }        
        public List<InvoiceItemsList> Items { get; init; }
        public string Notes { get; init; }
        public List<Tax> Taxes { get; init; }
        public decimal Subtotal { get; init; }
        public decimal Total { get; init; }
    }

    public class CreateTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateInvoiceCommand, int>
    {
        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            //var entity = new Invoice
            //{

            //    ListId = request.ListId,
            //    Title = request.Title,
            //    Done = false
            //};

            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            //await context.Invoices.Include().AddAsync(entity, cancellationToken);
            //await context.InvoiceItems.AddRangeAsync();

            //await _context.SaveChangesAsync(cancellationToken);

            //return entity.Id;
            return 0;
        }
    }
    public class CreateInvoice
    {
    }
}
