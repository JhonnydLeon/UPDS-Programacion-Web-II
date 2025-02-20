using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PedidoDb.Data;
using PedidoDb.Modelos;
using PedidoDb.Modelos.Dto;
using PedidoDb.Repositorio;

namespace PedidoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VentasController : ControllerBase
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        protected ResponseDto _response;

        public VentasController(IVentaRepositorio ventaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            try
            {
                var lista = await _ventaRepositorio.GetVentas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Ventas";
            }

            catch (SecurityTokenException ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Token invalido o expirado";
                _response.ErrorMessages = new List<string> { ex.Message };
                return Unauthorized(_response);// retornar 401
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _ventaRepositorio.GetVentaById(id);
            if (venta == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Venta no Existe";
                return NotFound(_response);
            }
            _response.Result = venta;
            _response.DisplayMessage = "Informacion del Venta";
            return Ok(_response);
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, VentaDto ventaDto)
        {
           try
           {
                VentaDto model = await _ventaRepositorio.CreateUpdate(ventaDto);
                _response.Result = model;
                return Ok(_response);
           }
           catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Actualizar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString ()};
                return BadRequest(_response);
            }
        }

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(VentaDto ventaDto)
        {
            try
            {
                VentaDto model = await _ventaRepositorio.CreateUpdate(ventaDto);
                _response.Result = model;
                return CreatedAtAction("GetVenta", new { id = model.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            try
            {
                bool estaEliminado = await _ventaRepositorio.DeleteVenta(id);
                if(estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Venta Eliminado con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Venta";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

       
    }
}
