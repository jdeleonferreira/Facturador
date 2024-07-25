using AutoMapper;
using Facturador.Web.Custom;
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
        private readonly Utilidades _utilidades;

        public CustomerController(InvoiceContext context, IMapper mapper, Utilidades utilidades)
        {
            _mapper = mapper;
            _context = context;
            _utilidades = utilidades;
        }



        [HttpGet]
        //Get: List of customers
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IList<Customer> listCustomers = await _context.Customers.ToListAsync();
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

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customerFound = await _context.Customers.FindAsync(id);
                if (customerFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro encontrado correctamente", customerFound });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var customerFound = await _context.Customers.FirstOrDefaultAsync(c => c.Name == name);
                if (customerFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro encontrado correctamente", customerFound });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Create Customer
        [HttpPost]

        public async Task<IActionResult> Post(CustomerDTO customerDTO)
        {
            try
            {
                customerDTO.PasswordCustomer = _utilidades.EncriptationSHA256(customerDTO.PasswordCustomer);
                var customer = _mapper.Map<Customer>(customerDTO);
                var customerFound = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customer.Email);
                if (customerFound != null) { return StatusCode(StatusCodes.Status302Found, new { isSuccess = "Customer ya existente" }); }
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Customer registrado correctamente" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }





        //Delete customer 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var CustomerFound = await _context.Customers.FindAsync(id);
                if (CustomerFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                _context.Customers.Remove(CustomerFound);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro eliminado correctamente" });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }
}
