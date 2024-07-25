using Facturador.Web.DTOs;
using Facturador.Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Facturador.Web.Interfaces
{

    public interface ICustomerReader
    {
        Task<IList<Customer>> GetAll();
        Task<Customer> Get(int id);



    }


    public interface ICustomerWriter
    {
        Task<Boolean> AddCustomer(CustomerDTO customerDTO);

        Task<Boolean> DeleteCustomer(int id);
    }

}
