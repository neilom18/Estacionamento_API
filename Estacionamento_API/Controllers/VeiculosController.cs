using Estacionamento_API.DTOs;
using Estacionamento_API.DTOs.PagamentoDTO;
using Estacionamento_API.Entidades;
using Estacionamento_API.Entidades.Pagamento;
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
        [HttpPost, Route("{id}/saida")]
        public IActionResult Saida(Guid id, FinalizarPagamentoDTO pagamentoDTO)
        {
            pagamentoDTO.Validar();
            try
            {
                var veiculo = _veiculosService.Get(id);
                pagamentoDTO.Validar();
                if (!pagamentoDTO.Valido) return BadRequest();
                switch (pagamentoDTO.TipoPagamento)
                {
                    case EFormaPagamento.CartaoCredito:
                        var credito = new FinalizarPagamento(
                        placa: veiculo.Placa,
                        cartaoCredito: new CartaoCredito(
                            cVV: pagamentoDTO.CartaoCreditoDTO.CVV,
                            nomeTitular: pagamentoDTO.CartaoCreditoDTO.Titular,
                            numeroConta: pagamentoDTO.CartaoCreditoDTO.Numero,
                            limite: pagamentoDTO.CartaoCreditoDTO.Limite,
                            validade: pagamentoDTO.CartaoCreditoDTO.Validade) );

                        _veiculosService.RetirarVeiculo(id, credito);
                        return Ok(veiculo);
                    case EFormaPagamento.CartaoDebito:
                        var debito = new FinalizarPagamento(
                        placa: veiculo.Placa,
                        cartaoDebito: new CartaoDebito(
                            cVV: pagamentoDTO.CartaoDebitoDTO.CVV,
                            nomeTitular: pagamentoDTO.CartaoDebitoDTO.Titular,
                            numeroConta: pagamentoDTO.CartaoDebitoDTO.Numero,
                            saldo: pagamentoDTO.CartaoDebitoDTO.Saldo,
                            validade: pagamentoDTO.CartaoDebitoDTO.Validade));
                        _veiculosService.RetirarVeiculo(id, debito);
                        return Ok(veiculo);
                    case EFormaPagamento.Pix:
                        var pix = new FinalizarPagamento(
                        placa: veiculo.Placa,
                        pix: new Pix(
                            agencia: pagamentoDTO.PixDTO.Agencia,
                            nomeTitular: pagamentoDTO.PixDTO.NomeTitular,
                            numeroConta: pagamentoDTO.PixDTO.NumeroConta,
                            instituicao: pagamentoDTO.PixDTO.Instituicao,
                            tipoChave: pagamentoDTO.PixDTO.TipoChave));
                        _veiculosService.RetirarVeiculo(id, pix);
                        return Ok(veiculo);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(VeiculoDTO veiculoDTO)
        {
            veiculoDTO.Validar();
            var c = _clienteService.Get(veiculoDTO.Cliente.Documento);
            if (veiculoDTO == null || !veiculoDTO.Valido) return BadRequest();

            if (veiculoDTO.TipoVeiculo == ETipoVeiculo.Carro)
            {
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
            }
            else if (veiculoDTO.TipoVeiculo == ETipoVeiculo.Moto)
            {
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
