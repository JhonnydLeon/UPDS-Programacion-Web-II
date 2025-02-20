using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidoDb.Data;
using PedidoDb.Modelos;
using PedidoDb.Modelos.Dto;

namespace PedidoDb.Repositorio
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly PedidosDbContext _db;
        private IMapper _mapper;

        public VentaRepositorio(PedidosDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<VentaDto> CreateUpdate(VentaDto ventaDto)
        {
            Venta venta = _mapper.Map<VentaDto, Venta>(ventaDto);
            if (venta.Id > 0)
            {
                _db.Ventas.Update(venta);
            }
            else
            {
                await _db.Ventas.AddAsync(venta);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Venta, VentaDto>(venta);
        }

        public async Task<bool> DeleteVenta(int id)
        {
            try
            {
                Venta venta = await _db.Ventas.FindAsync(id);
                if (venta == null)
                {
                    return false;
                }
                _db.Ventas.Remove(venta);
                await _db.SaveChangesAsync();
                return true;    
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<VentaDto> GetVentaById(int id)
        {
            Venta venta = await _db.Ventas.FindAsync(id);
            return _mapper.Map<VentaDto>(venta);
        }

        public async Task<List<VentaDto>> GetVentas()
        {
            List<Venta> lista = await _db.Ventas.ToListAsync();

            return _mapper.Map<List<VentaDto>>(lista);
        }
    }
}
