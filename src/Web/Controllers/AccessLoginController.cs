using Facturador.Web.Custom;
using Facturador.Web.Entities;
using Facturador.Web.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessLoginController : ControllerBase
    {
        private readonly InvoiceContext _context;
        private readonly Utilidades _utilidades;
        public AccessLoginController(InvoiceContext context, Utilidades utilidades )
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
             await _context.SaveChangesAsync(); 

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
            //Pasar a domain Layer
            var customerFound = await  _context.Customers.Where(u => u.Email == objeto.Email
                                                                && u.PasswordCustomer == _utilidades.EncriptationSHA256(objeto.PasswordCustomer))
                                                               .FirstOrDefaultAsync();
            if (customerFound == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucces = false, token = "" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSucces = true, token= _utilidades.GenerarJWT(customerFound)});
            }

        }
    }
}
