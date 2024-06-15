using Facturador.Web.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
       
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
                List<InvoiceItem> listInvoice = _context.InvoiceItems.ToList();
                if (listInvoice == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Listado encontrado", listInvoice });

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
                var invoiceOne = _context.InvoiceItems.Find(id);
                if (invoiceOne == null) { StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Invoice encontrada", invoiceOne });

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
                if (InvoiceFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                _context.InvoiceItems.Remove(InvoiceFound);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Invoice eliminado correctamente" });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
