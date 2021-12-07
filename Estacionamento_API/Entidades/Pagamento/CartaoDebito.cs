using System;

namespace Estacionamento_API.Entidades.Pagamento
{
    public class CartaoDebito
    {
        public CartaoDebito(string cVV, string nomeTitular, string numeroConta, decimal saldo, DateTime validade)
        {
            CVV = cVV;
            NomeTitular = nomeTitular;
            NumeroConta = numeroConta;
            Saldo = saldo;
            Validade = validade;
        }

        public string CVV { get; private set; }
        public string NomeTitular { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal Saldo { get; private set; }
        public DateTime Validade { get; private set; }
    }
}
