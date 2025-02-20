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
    public class TrabajadorsController : ControllerBase
    {
        private readonly ITrabajadorRepositorio _trabajadorRepositorio;
        protected ResponseDto _response;

        public TrabajadorsController(ITrabajadorRepositorio trabajadorRepositorio)
        {
            _trabajadorRepositorio = trabajadorRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Trabajadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajador>>> GetTrabajadores()
        {
            try
            {
                var lista = await _trabajadorRepositorio.GetTrabajadores();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Trabajadores";
            }
            catch (SecurityTokenException ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Token invalido o expirado";
                _response.ErrorMessages = new List<string> { ex.Message };
                return Unauthorized(_response);//retornar 401
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };

            }
            return Ok(_response);
        }

        // GET: api/Trabajadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajador>> GetTrabajador(int id)
        {
            var trabajador = await _trabajadorRepositorio.GetTrabajadorByID(id);
            if (trabajador == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Trabajador No Existe";
                return NotFound(_response);
            }
            _response.Result = trabajador;
            _response.DisplayMessage = "Informacion del Trabajador";
            return Ok(_response);
        }

        // PUT: api/Trabajadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajador(int id, TrabajadorDto trabajadorDto)
        {
           try
            {
                TrabajadorDto model = await _trabajadorRepositorio.CreateUpdate(trabajadorDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error Al Actualizar el Registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Trabajadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trabajador>> PostTrabajador(TrabajadorDto trabajadorDto)
        {
           try
            {
                TrabajadorDto model = await _trabajadorRepositorio.CreateUpdate(trabajadorDto);
                _response.Result = model;
                return CreatedAtAction("GetTrabajador", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Grabar el Regitro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Trabajadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajador(int id)
        {
            try
            {
                bool estaEliminado = await _trabajadorRepositorio.DeleteTrabajador(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Trabajador Eliminado con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Trabajador";
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
