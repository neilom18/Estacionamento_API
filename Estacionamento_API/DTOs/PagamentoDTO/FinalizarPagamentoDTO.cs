using Estacionamento_API.Enumerados;

namespace Estacionamento_API.DTOs.PagamentoDTO
{
    public class FinalizarPagamentoDTO : Validator
    {
        public CartaoCreditoDTO? CartaoCreditoDTO { get; set; }
        public CartaoDebitoDTO? CartaoDebitoDTO { get; set; }
        public PixDTO? PixDTO { get; set; }
        public EFormaPagamento TipoPagamento { get; set; }

        public override void Validar()
        {
            Valido = true;
            switch (TipoPagamento)
            {
                case EFormaPagamento.CartaoDebito:
                    CartaoDebitoDTO.Validar();
                    if(!CartaoDebitoDTO.Valido) Valido = false;
                    break;
                case EFormaPagamento.CartaoCredito:
                    CartaoCreditoDTO.Validar();
                    if(!CartaoCreditoDTO.Valido) Valido = false;
                    break;
                case EFormaPagamento.Pix:
                    PixDTO.Validar();
                    if(!PixDTO.Valido) Valido = false;
                    break;
            }
        }
    }
}
