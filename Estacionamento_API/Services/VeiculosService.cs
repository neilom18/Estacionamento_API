using Estacionamento_API.Entidades;
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
        public void RetirarVeiculo(string placa)
        {
            var veiculo =_veiculos.Where(v => v.Placa == placa).FirstOrDefault();
            veiculo.CalcularPreço();
            // Pagamento
            veiculo.SetSaida();
        }
    }
}
