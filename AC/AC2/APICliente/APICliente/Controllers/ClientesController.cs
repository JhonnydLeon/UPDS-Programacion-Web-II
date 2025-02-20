using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICliente.Data;
using APICliente.Modelos;
using APICliente.Repositorio;
using APICliente.Modelos.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        protected ReponseDto _response;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _response = new ReponseDto();
        }

        // GET: api/Clientes (Solo accesible por usuarios autenticados)
        [HttpGet]
        //[Authorize] // Asegura que solo los usuarios logueados puedan acceder
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var lista = await _clienteRepositorio.GetClientes();
                _response.Result = lista;
                _response.DisplayMessage = "lista de clientes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        //[Authorize] // Permite que cualquiera vea la información del cliente
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteRepositorio.GetClienteById(id);

            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Cliente no existe";
                return NotFound(_response);
            }
            _response.Result = cliente;
            _response.DisplayMessage = "Informacion del cliente";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        //[Authorize] // Solo los usuarios logueados pueden actualizar
        public async Task<IActionResult> PutCliente(int id, ClienteDto clientedto)
        {
            try
            {
                ClienteDto model = await _clienteRepositorio.CreateUpdate(clientedto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "error al actualizar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Clientes
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDto clientedto)
        {
            try
            {
                ClienteDto model = await _clienteRepositorio.CreateUpdate(clientedto);
                _response.Result = model;
                return CreatedAtAction("GetCliente", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "error al guardar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        //[Authorize] // Solo los usuarios logueados pueden eliminar clientes
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                bool estaEliminado = await _clienteRepositorio.DeleteCliente(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "error al eliminar al cliente";
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
