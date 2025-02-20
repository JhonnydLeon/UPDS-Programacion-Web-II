using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PedidoDb.Data;
using PedidoDb.Modelos;
using PedidoDb.Modelos.Dto;
using System.Collections.Generic;

namespace PedidoDb.Repositorio
{
    public class TrabajadorRepositorio : ITrabajadorRepositorio
    {
        private readonly PedidosDbContext _db;
        private IMapper _mapper;

        public TrabajadorRepositorio(PedidosDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<TrabajadorDto> CreateUpdate(TrabajadorDto trabajadorDto)
        {
            Trabajador trabajador = _mapper.Map < TrabajadorDto, Trabajador>(trabajadorDto);
            if (trabajador.Id > 0)
            {
                _db.Trabajadores.Update(trabajador);
            }
            else
            {
                await _db.Trabajadores.AddAsync(trabajador);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Trabajador, TrabajadorDto>(trabajador);
        }

        public async Task<bool> DeleteTrabajador(int id)
        {
            try
            {
                Trabajador trabajador = await _db.Trabajadores.FindAsync(id);
                if (trabajador == null)
                {
                    return false;
                }
                _db.Trabajadores.Remove(trabajador);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

        public async Task<TrabajadorDto> GetTrabajadorByID(int id)
        {
            Trabajador trabajador = await _db.Trabajadores.FindAsync(id);
            return _mapper.Map<TrabajadorDto>(trabajador);
        }

        public async Task<List<TrabajadorDto>> GetTrabajadores()
        {
           List<Trabajador> lista = await _db.Trabajadores.ToListAsync();
            return _mapper.Map<List<TrabajadorDto>>(lista);
        }
    }
}
