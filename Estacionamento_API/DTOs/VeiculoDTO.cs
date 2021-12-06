using Estacionamento_API.Enumerados;

namespace Estacionamento_API.DTOs
{
    public class VeiculoDTO : Validator
    {
        public ClienteDTO Cliente { get; set; }
        public CarroDTO? Carro { get; set; }
        public MotoDTO? Moto { get; set; }
        public ETipoVeiculo TipoVeiculo { get; set; }

        public override void Validar()
        {
            Cliente.Validar();
            if (Cliente.Valido)
            {

            }
        }
    }
}
