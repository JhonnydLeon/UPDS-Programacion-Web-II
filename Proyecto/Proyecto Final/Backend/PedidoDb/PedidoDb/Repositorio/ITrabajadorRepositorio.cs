using PedidoDb.Modelos.Dto;
using System.Threading.Tasks;

namespace PedidoDb.Repositorio
{
    public interface ITrabajadorRepositorio
    {
        Task<List<TrabajadorDto>> GetTrabajadores();
        Task<TrabajadorDto> GetTrabajadorByID(int id);
        Task<TrabajadorDto> CreateUpdate(TrabajadorDto trabajadorDto);
        Task<bool> DeleteTrabajador(int id);
    }
}
