using Facturador.Web.Reverse;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        //BD - Enlace
        private readonly InvoiceContext _context;
        public InvoiceItemController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        //Get: List of invoicesItems

        public IActionResult GetAll()
        {
            try
            {
                List<InvoiceItem> ListInvoice = _context.InvoiceItems.ToList();
                if (ListInvoice == null) { return NotFound("No se encontraron registros"); }
                return Ok(ListInvoice);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //One Invoiceitems
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                var InvoiceOne = _context.InvoiceItems.Find(id);
                if (InvoiceOne == null) { return NotFound("Registro no encontrado"); }
                return Ok(InvoiceOne);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete invoiceItem
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                var InvoiceFound = _context.InvoiceItems.Find(id);
                if (InvoiceFound == null) { return NotFound("Registro no encontrado"); }
                _context.InvoiceItems.Remove(InvoiceFound);
                _context.SaveChanges();

                return Ok("Invoice eliminado correctamente");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
