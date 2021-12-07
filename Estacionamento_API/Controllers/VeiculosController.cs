using Estacionamento_API.DTOs;
using Estacionamento_API.Entidades;
using Estacionamento_API.Enumerados;
using Estacionamento_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Estacionamento_API.Controllers
{
    [ApiController, Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly VeiculosService _veiculosService;
        private readonly ClienteService _clienteService;
        public VeiculosController(VeiculosService veiculosService, ClienteService clienteService)
        {
            _veiculosService = veiculosService;
            _clienteService = clienteService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_veiculosService.Get());
        }
        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_veiculosService.Get(id));
        }
        [HttpPost]
        public IActionResult Post(VeiculoDTO veiculoDTO)
        {
            veiculoDTO.Validar();
            var c = _clienteService.Get(veiculoDTO.Cliente.Documento);
            if (veiculoDTO == null || !veiculoDTO.Valido) return BadRequest();
            switch (veiculoDTO.TipoVeiculo)
            {
                case ETipoVeiculo.Carro:
                    if (c is null)
                    {
                        c = new Cliente(veiculoDTO.Cliente.Nome, veiculoDTO.Cliente.Documento);
                        _clienteService.Adicionar(c);
                    }
                    var carro = new Veiculo(veiculoDTO.TipoVeiculo,
                        carro: new Carro(
                        largura: veiculoDTO.Carro.Largura,
                        placa: veiculoDTO.Carro.Placa,
                        diaria: veiculoDTO.Carro.Diaria,
                        lavagem: veiculoDTO.Carro.Lavagem),
                        entrada: veiculoDTO.Carro.Entrada,
                        cliente: c);
                    _clienteService.AdicionarVeiculo(carro);
                    return Ok(_veiculosService.Adicionar(carro));
                case ETipoVeiculo.Moto:
                    if (c is null)
                    {
                        c = new Cliente(veiculoDTO.Cliente.Nome, veiculoDTO.Cliente.Documento);
                        _clienteService.Adicionar(c);
                    }
                    var moto = new Veiculo(veiculoDTO.TipoVeiculo,
                        moto: new Moto(
                        largura: veiculoDTO.Moto.Largura,
                        placa: veiculoDTO.Moto.Placa),
                        entrada: veiculoDTO.Moto.Entrada,
                        cliente: c);
                    _clienteService.AdicionarVeiculo(moto);
                    return Ok(_veiculosService.Adicionar(moto));
            }
            return BadRequest();
        }
    }
}
