using APICliente.Modelos.Dto;
using APICliente.Modelos;
using AutoMapper;

namespace APICliente
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Mapeo entre ClienteDto y Cliente
                config.CreateMap<ClienteDto, Cliente>();

                // Mapeo entre Cliente y ClienteDto
                config.CreateMap<Cliente, ClienteDto>();
            });

            return mappingConfig;
        }
    }
}
