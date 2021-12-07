using Estacionamento_API.Enumerados;

namespace Estacionamento_API.Entidades.Pagamento
{
    public class Pix
    {
        public Pix(string agencia, string nomeTitular, string numeroConta, string instituicao, ETipoChavePix tipoChave)
        {
            Agencia = agencia;
            NomeTitular = nomeTitular;
            NumeroConta = numeroConta;
            Instituicao = instituicao;
            TipoChave = tipoChave;
        }

        public string Agencia { get;private set; }
        public string NomeTitular { get;private set; }
        public string NumeroConta { get;private set; }
        public string Instituicao { get;private set; }
        public ETipoChavePix TipoChave { get;private set; }
    }
}
