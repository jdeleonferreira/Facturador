using AutoMapper;
using Facturador.Web.Custom;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;
using Facturador.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Facturador.Web.Logic
{

    //Servicios de Lectura
    public class CustomerServicesReader : ICustomerReader
    {

        private readonly InvoiceContext _context;
        private readonly IMapper _mapper;
        private readonly Utilidades _utilidades;

        public CustomerServicesReader(InvoiceContext context, IMapper mapper, Utilidades utilidades)
        {
            _mapper = mapper;
            _context = context;
            _utilidades = utilidades;
        }

        //Primer Metodo de lectura 
        public async Task<IList<Customer>> GetAll()
        {
            try
            {
                IList<Customer> listCustomers = await _context.Customers.ToListAsync();
                if (listCustomers == null)
                {
                    throw new Exception("Registro no encontrado");
                }

                return listCustomers;

            }
            catch
            {
                throw new Exception("No se pudo realiazar la consulta");
            }

        }


        //Segundo Metodo de lectura 

        public async Task<Customer> Get(int id)
        {
            try
            {
                var customerFound = await _context.Customers.FindAsync(id);
                if (customerFound == null) { throw new Exception("Registro no encontrado"); }

                return customerFound;

            }
            catch
            {
                throw new Exception("No se pudo realiazar la consulta");
            }
        }

    }






    //Servicios de Escritura
    public class CustomerServicesWriter : ICustomerWriter
    {

        private readonly InvoiceContext _context;
        private readonly IMapper _mapper;
        private readonly Utilidades _utilidades;

        public CustomerServicesWriter(InvoiceContext context, IMapper mapper, Utilidades utilidades)
        {
            _mapper = mapper;
            _context = context;
            _utilidades = utilidades;
        }

        public async Task<Boolean> AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                customerDTO.PasswordCustomer = _utilidades.EncriptationSHA256(customerDTO.PasswordCustomer);

                var customer = _mapper.Map<Customer>(customerDTO);

                var customerFound = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customer.Email);
                if (customerFound != null) { throw new Exception("Customer Ya existente"); }
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw new Exception("No se pudo registrar el Customer");
            }
        }

        public async Task<Boolean> DeleteCustomer(int id)
        {
            try
            {
                var CustomerFound = await _context.Customers.FindAsync(id);
                if (CustomerFound == null) { throw new Exception("Registro no encontrado"); }
                _context.Customers.Remove(CustomerFound);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
