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
            Valido = true;
            Cliente.Validar();
            if (Cliente.Valido)
            {
                switch (TipoVeiculo)
                {
                    case ETipoVeiculo.Carro:
                        Carro.Validar();
                        if(!Carro.Valido) Valido = false;
                        break;

                    case ETipoVeiculo.Moto:
                        Moto.Validar();
                        if (!Moto.Valido) Valido = false;
                        break;
                }
            }else Valido = false;
        }
    }
}
