using PedidoDb.Modelos.Dto;
using System.Threading.Tasks;

namespace PedidoDb.Repositorio
{
    public interface IVentaRepositorio
    {
        Task<List<VentaDto>> GetVentas();
        Task<VentaDto> GetVentaById(int id);
        Task<VentaDto> CreateUpdate(VentaDto ventaDto);
        Task<bool> DeleteVenta(int id);
    }
}
