using AutoMapper;
using PedidoDb.Modelos.Dto;
using PedidoDb.Modelos;
using PedidoDb.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PedidoDb.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly PedidosDbContext _db;
        private IMapper _mapper;

        public ClienteRepositorio(PedidosDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClienteDto> CreateUpdate(ClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDto, Cliente>(clienteDto);
            if (cliente.Id > 0)
            {
                _db.Clientes.Update(cliente);
            }
            else
            {
                await _db.Clientes.AddAsync(cliente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                Cliente cliente = await _db.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }
                _db.Clientes.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            Cliente cliente = await _db.Clientes.FindAsync(id);

            return _mapper.Map<ClienteDto>(cliente);

        }

        public async Task<List<ClienteDto>> GetClientes()
        {
            List<Cliente> lista = await _db.Clientes.ToListAsync();

            return _mapper.Map<List<ClienteDto>>(lista);
        }
    }
}
