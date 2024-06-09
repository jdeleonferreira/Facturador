using Facturador.Web.Reverse;
using Microsoft.AspNetCore.Mvc;


namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        //BD - Enlace
        private readonly InvoiceContext _context;

        public CustomerController(InvoiceContext context)
        {

            _context = context;
        }


        [HttpGet]
        
        //Get: List of customers
        public IActionResult GetAll()
        {
            try
            {
                List<Customer> ListCustomers = _context.Customers.ToList();
                if (ListCustomers == null) { return NotFound("No se encontraron registros"); }
                return Ok(ListCustomers);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //One Customer
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                var CustomerFound = _context.Customers.Find(id);
                if (CustomerFound == null) { return NotFound("Registro no encontrado"); }
                return Ok(CustomerFound);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //Delete customer 
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                var CustomerFound = _context.Customers.Find(id);
                if (CustomerFound == null) { return NotFound("Registro no encontrado"); }
                _context.Customers.Remove(CustomerFound);
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
