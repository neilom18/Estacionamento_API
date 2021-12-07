using Estacionamento_API.Enumerados;

namespace Estacionamento_API.DTOs.PagamentoDTO
{
    public class PixDTO : Validator
    {
        public string Agencia { get; set; }
        public string NomeTitular { get; set; }
        public string NumeroConta { get; set; }
        public string Instituicao { get; set; }
        public ETipoChavePix TipoChave { get; set; }

        public override void Validar()
        {
            Valido = true;
        }
    }
}
