using System;

namespace Estacionamento_API.Entidades.Pagamento
{
    public class CartaoCredito
    {
        public CartaoCredito(string cVV, string nomeTitular, string numeroConta, decimal limite, DateTime validade)
        {
            CVV = cVV;
            NomeTitular = nomeTitular;
            NumeroConta = numeroConta;
            Limite = limite;
            Validade = validade;
        }

        public string CVV { get;private set; }
        public string NomeTitular { get;private set; }
        public string NumeroConta { get;private set; }
        public decimal Limite { get;private set; }
        public DateTime Validade { get; private set; }
    }
}
