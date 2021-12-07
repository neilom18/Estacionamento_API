using Estacionamento_API.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento_API.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes;
        private readonly VeiculosService _veiculosService;
        public ClienteService(VeiculosService veiculosService)
        {
            _clientes = new List<Cliente>();
            _veiculosService = veiculosService;
        }

        public IEnumerable<Cliente> Get()
        {
            return _clientes;
        }
        public Cliente Get(Guid id)
        {
            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }
        public Cliente Get(string Documento)
        {
            return _clientes.Where(x => x.Documento == Documento).FirstOrDefault();
        }
        public Cliente Adicionar(Cliente cliente)
        {
            if (Get(cliente.Documento) != null)
                throw new Exception("Cliente já cadastrado!");
            _clientes.Add(cliente);
            return cliente;
        }
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            var cliente = _clientes.Where(x => x.Documento == veiculo.Cliente.Documento).FirstOrDefault();
            var v = cliente.Veiculos.Where(d => d.Placa == veiculo.Placa).FirstOrDefault();
            if (v == null)
                veiculo.Cliente.AddVeiculo(veiculo);
        }
        public void Deletar(Guid id)
        {
            try
            {
                _veiculosService.Deletar(id);
                _clientes.Remove(Get(id));
            }catch (Exception)
            {
                throw new Exception("Não foi possivel remover o cliente/veiculo");
            }
        }
    }
}
