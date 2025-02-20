using AutoMapper;
using PedidoDb.Modelos;
using PedidoDb.Modelos.Dto;

namespace PedidoDb
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClienteDto, Cliente>();
                config.CreateMap<Cliente, ClienteDto>();

                config.CreateMap<TrabajadorDto, Trabajador>();
                config.CreateMap<Trabajador, TrabajadorDto>();

                config.CreateMap<VentaDto, Venta>();
                config.CreateMap<Venta, VentaDto>();
            });

            return mappingConfig;
        }
    }
}
