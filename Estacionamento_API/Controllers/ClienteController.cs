using Estacionamento_API.DTOs;
using Estacionamento_API.Entidades;
using Estacionamento_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Estacionamento_API.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteService.Get());
        }
        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_clienteService.Get(id));
        }
        [HttpPut]
        public IActionResult Put(ClienteDTO clienteDTO) 
        {
            var cliente = new Cliente(
                clienteDTO.Nome, clienteDTO.Documento);

            return Ok(_clienteService.Adicionar(cliente));
        }
/*        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {

        }*/
    }
}
