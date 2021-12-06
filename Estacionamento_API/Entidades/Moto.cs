using System;

namespace Estacionamento_API.Entidades
{
    public class Moto
    {
        public Moto(decimal largura, string placa, bool diaria = false)
        {
            Largura = largura;
            Placa = placa;
            Diaria = diaria;
        }
        public decimal Largura { get; private set; }
        public string Placa { get; private set; }
        public bool Diaria { get; private set; } = false;
    }
}
