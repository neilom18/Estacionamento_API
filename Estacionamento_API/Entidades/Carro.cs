using System;

namespace Estacionamento_API.Entidades
{
    public class Carro
    {
        public Carro(decimal largura, string placa, bool diaria = false, bool lavagem = false)
        {
            Largura = largura;
            Placa = placa;
            Diaria = diaria;
            Lavagem = lavagem;
        }
        public decimal Largura { get; private set; }
        public string Placa { get; private set; }
        public bool Diaria { get; private set; }
        public bool Lavagem { get; private set; }
    }
}
