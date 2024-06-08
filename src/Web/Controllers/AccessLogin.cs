using Facturador.Web.Custom;
using Facturador.Web.Reverse;
using Facturador.Web.Reverse.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessLogin : ControllerBase
    {
        private readonly InvoiceContext _context;
        private readonly Utilidades _utilidades;
        public AccessLogin(InvoiceContext context, Utilidades utilidades )
        {
            _context = context; 
            _utilidades = utilidades;   
        }

        [HttpPost]
        [Route("Registrarse")]

        public async Task<IActionResult> Registrarse(CustomerDTO objeto) {

            var modelCustomer = new Customer
            {
                Id = objeto.Id,
                Email = objeto.Email,
                PasswordCustomer = _utilidades.EncriptationSHA256(objeto.PasswordCustomer), 


            };

            _context.Customers.Add(modelCustomer);
            _context.SaveChanges(); 

            if(modelCustomer.Id != 0) {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }   
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            Console.WriteLine(objeto.Email);
            Console.WriteLine(objeto.PasswordCustomer);
            Console.WriteLine("---------------------------");
            var customerFound = await  _context.Customers.Where(u => u.Email == objeto.Email)
                                                               .FirstOrDefaultAsync();

            Console.WriteLine("---------------------------");
            return Ok(customerFound.Equals(null));

            //if(customerFound == null)
            //{
            //    return StatusCode(StatusCodes.Status200OK, new { isSucces = false, token=""});
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status200OK, new { isSucces = true    });
            //}

        }
    }
}
