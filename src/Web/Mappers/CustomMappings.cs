using AutoMapper;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;

namespace Facturador.Web.Mappers
{
    internal class CustomMappings : ICustomMapper
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<CustomerDTO, Customer>();
        }
    }
}
