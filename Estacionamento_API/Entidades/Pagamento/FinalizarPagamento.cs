using Estacionamento_API.Enumerados;
using System;

namespace Estacionamento_API.Entidades.Pagamento
{
    public class FinalizarPagamento
    {
        public FinalizarPagamento(string placa, Pix pix)
        {
            Id = Guid.NewGuid();
            Pix = pix;
            Placa = placa;
        }
        public FinalizarPagamento(string placa, CartaoCredito cartaoCredito)
        {
            Id = Guid.NewGuid();
            CartaoCredito = cartaoCredito;
            Placa = placa;
        }
        public FinalizarPagamento(string placa, CartaoDebito cartaoDebito)
        {
            Id = Guid.NewGuid();
            CartaoDebito = cartaoDebito;
            Placa = placa;
        }

        public Pix? Pix { get; private set; }
        public CartaoCredito? CartaoCredito { get; private set; }
        public CartaoDebito? CartaoDebito { get; private set; }
        public EFormaPagamento FormaPagamento { get; private set; }
        public ETipoVeiculo TipoVeiculo { get; private set; }
        public Guid Id { get; private set; }
        public string Placa { get; private set; }
        public decimal Valor { get; private set; }

        public bool Valido { get; private set; } = false;
        public bool Pagar(decimal valor)
        {
            Valor = valor;
            if (Valor <= 0) Valido = false;
            Valido = true;
            switch (FormaPagamento)
            {
                case EFormaPagamento.CartaoCredito: // Tá valido confia
                    if (CartaoCredito == null) Valido = false;
                    if (CartaoCredito.Limite < Valor) Valido = false;
                    if (CartaoCredito.NomeTitular.Length < 4) Valido = false;
                    return Valido;

                case EFormaPagamento.CartaoDebito: // Tá valido confia
                    if (CartaoDebito == null) Valido = false;
                    if (CartaoDebito.Saldo < valor) Valido = false;
                    if (CartaoDebito.NomeTitular.Length < 4) Valido = false;
                    return Valido;

                case EFormaPagamento.Pix: // Tá valido confia
                    if (Pix == null) Valido = false;
                    if (Pix.NomeTitular.Length < 4) Valido = false;
                    if (Pix.NumeroConta.Length < 8) Valido = false;
                    return Valido;
            }
            return false;
        }
    }
}
