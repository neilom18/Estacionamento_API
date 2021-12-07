using Estacionamento_API.Entidades;
using Estacionamento_API.Entidades.Pagamento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento_API.Services
{
    public class VeiculosService
    {
        private readonly List<Veiculo> _veiculos;
        public VeiculosService()
        {
            _veiculos = new List<Veiculo>();
        }
        public IEnumerable<Veiculo> Get()
        {
            return _veiculos;
        }
        public Veiculo Get(Guid id)
        {
            var v = _veiculos.Where(x => x.Id == id).FirstOrDefault();
            if (v is null) throw new Exception("Veiculo não encontrado!");
            v.CalcularPreço();
            return v;
        }
        public Veiculo Adicionar(Veiculo veiculo)
        {
            if (_veiculos.Where(v => v.Placa == veiculo.Placa).FirstOrDefault() != null)
                throw new Exception("Um veiculo com essa placa já esta estacionado");
            _veiculos.Add(veiculo);
            return Get(veiculo.Id);
        }
        public void RetirarVeiculo(Guid id, FinalizarPagamento pagamento)
        {
            var veiculo = Get(id);
            if (veiculo is null)
                throw new Exception("Veiculo não encontrado!");
            veiculo.CalcularPreço();
            // Pagamento
            if(pagamento.Pagar((decimal)veiculo.ValorEstadia))
                veiculo.SetSaida();
        }
        public void Deletar(Guid id) // Deleta todos os veiculos de um cliente
        {
            var p = _veiculos.RemoveAll(y => y.Cliente.Id == id);
        }
    }
}
