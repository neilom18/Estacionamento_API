using System;

namespace Estacionamento_API.DTOs
{
    public class CarroDTO : Validator
    {
        public DateTime Entrada { get; set; }
        public decimal Largura { get; set; }
        public string Placa { get; set; }
        public bool Diaria { get; set; } = false;
        public bool Lavagem { get; set; } = false;

        public override void Validar()
        {
            Valido = true;
            var t = DateTime.Compare(DateTime.Now, Entrada);
            if (t < 0 || t == 0)
                Valido = false;
            if(Largura == 0) Valido = false;
        }
    }
}
