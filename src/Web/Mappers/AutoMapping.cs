using AutoMapper;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;

namespace Facturador.Web.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerDTO, Customer>();

        }
    }
}
