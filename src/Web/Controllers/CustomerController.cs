using AutoMapper;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly InvoiceContext _context;
        private readonly IMapper _mapper;

        public CustomerController(InvoiceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        //Get: List of customers
        public IActionResult GetAll()
        {
            try
            {
                List<Customer> listCustomers = _context.Customers.ToList();
                if (listCustomers == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "listado encontrado correctamente", listCustomers });

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
                var customerFound = _context.Customers.Find(id);
                if (customerFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro encontrado correctamente", customerFound });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


                await _context.Customers.AddAsync(customer);


        //Delete customer 
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                var CustomerFound = _context.Customers.Find(id);
                if (CustomerFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                _context.Customers.Remove(CustomerFound);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro eliminado correctamente" });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
