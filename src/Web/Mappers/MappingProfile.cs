using AutoMapper;
using Facturador.Web.DTOs;
using Facturador.Web.Entities;

namespace Facturador.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            var customMappers = new List<ICustomMapper>
            {
                new CustomMappings()
            };

            foreach (var customMapper in customMappers)
            {
                customMapper.CreateMappings(this);
            }


        }
    }
}
