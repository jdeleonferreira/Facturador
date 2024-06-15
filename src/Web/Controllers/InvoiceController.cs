
using Facturador.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Facturador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly InvoiceContext _context;
        public InvoiceController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        //Get: List of invoices

        public IActionResult GetAll()
        {
            try
            {
                List<Invoice>  ListInvoice = _context.Invoices.ToList();
                if (ListInvoice == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "listado encontrado correctamente", ListInvoice}); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //One Invoice
        [HttpGet("{id}")]

        public IActionResult  Get(int id)
        {
            try
            {
                var invoiceOne = _context.Invoices.Find(id);
                if (invoiceOne == null) {return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Invoice encontrada correctamente", invoiceOne });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete invoice
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                var InvoiceFound = _context.Invoices.Find(id);
                if (InvoiceFound == null) {return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                _context.Invoices.Remove(InvoiceFound);
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
