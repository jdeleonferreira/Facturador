using AutoMapper;
using Facturador.Web.Custom;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;
using Facturador.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;


namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerReader _CustomerReader;
        private readonly ICustomerWriter _CustomerWriter;


        public CustomerController(ICustomerWriter customerWriter, ICustomerReader customerReader)
        {
            _CustomerReader = customerReader ?? throw new ArgumentNullException(nameof(customerReader));
            _CustomerWriter = customerWriter ?? throw new ArgumentNullException(nameof(customerWriter));
        }

        [HttpGet]

        //Get: List of customers
        public async Task<IActionResult> GetAllCustomer()
        {
            var listCustomers = await _CustomerReader.GetAll();
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = "listado encontrado correctamente", listCustomers });

        }

        //One Customer
        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customerFound = await _CustomerReader.Get(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro encontrado correctamente", customerFound });
        }


        ////Create Customer
        [HttpPost]

        public async Task<IActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            Console.WriteLine(customerDTO);
            var customerStatus = await _CustomerWriter.AddCustomer(customerDTO);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Customer registrado correctamente" });
        }

        ////Delete customer 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customestatus = await _CustomerWriter.DeleteCustomer(id);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro eliminado correctamente" });

        }



    }
}


