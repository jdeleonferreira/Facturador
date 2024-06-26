﻿
using Facturador.Web.Reverse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Facturador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        //BD - Enlace
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
                if (ListInvoice == null) { return NotFound("No se encontraron registros"); }
                return Ok(ListInvoice);

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
                var InvoiceOne = _context.Invoices.Find(id);
                if (InvoiceOne == null) {return NotFound("Registro no encontrado"); }
                return Ok(InvoiceOne);

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
                if (InvoiceFound == null) {return NotFound("Registro no encontrado"); }
                _context.Invoices.Remove(InvoiceFound);
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
