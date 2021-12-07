using System;

namespace Estacionamento_API.DTOs.PagamentoDTO
{
    public class CartaoDebitoDTO : Validator
    {
        public string CVV { get; set; }
        public string Numero { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Validade { get; set; }

        public override void Validar()
        {
            Valido = true;
        }
    }
}
