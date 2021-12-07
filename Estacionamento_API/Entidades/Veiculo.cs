using Estacionamento_API.Enumerados;
using System;

namespace Estacionamento_API.Entidades
{
    public class Veiculo
    {
        public Veiculo(ETipoVeiculo tipoVeiculo, Carro carro, DateTime entrada, Cliente cliente)
        {
            Id = Guid.NewGuid();
            TipoVeiculo = tipoVeiculo;
            Carro = carro;
            Placa = Carro.Placa;
            Entrada = entrada;
            Cliente = cliente;
        }

        public Veiculo(ETipoVeiculo tipoVeiculo, Moto moto, DateTime entrada, Cliente cliente)
        {
            Id = Guid.NewGuid();
            TipoVeiculo = tipoVeiculo;
            Moto = moto;
            Placa = Moto.Placa;
            Entrada = entrada;
            Cliente = cliente;
        }
        public Veiculo(ETipoVeiculo tipoVeiculo, string placa)
        {
            TipoVeiculo = tipoVeiculo;
            Placa = placa;
        }
        public Guid Id { get;private set; }
        public ETipoVeiculo TipoVeiculo { get; private set; }
        public Carro? Carro { get; private set; }
        public Moto? Moto { get; private set; }
        public DateTime Entrada { get; private set; }
        public DateTime? Saida { get; private set; }
        public TimeSpan TempoPermanencia { get; private set; }
        public string Placa { get;private set; }
        public decimal? ValorEstadia { get; private set; }
        public Cliente Cliente { get;private set; }

        public void CalcularPreço()
        {
            TempoPermanencia = DateTime.Now - Entrada;
            switch (TipoVeiculo)
            {
                case ETipoVeiculo.Carro:
                    if (Carro.Diaria)
                    {
                        if (Carro.Lavagem)
                        {
                            ValorEstadia = (decimal.Round(TempoPermanencia.Days + 1)) * 65;
                        }
                        ValorEstadia = (decimal.Round(TempoPermanencia.Days + 1)) * 60;
                    }
                    else if(TempoPermanencia.TotalMinutes <= 15)
                    {
                        ValorEstadia = 2m;
                    }
                    else if(TempoPermanencia.TotalMinutes > 15)
                    {
                        decimal valor = (decimal)TempoPermanencia.TotalHours * 10;
                        decimal.Round(valor, 2);
                        ValorEstadia = valor;
                    }
                    break;

                case ETipoVeiculo.Moto:
                    TempoPermanencia = DateTime.Now - Entrada;
                    if (Moto.Diaria == true)
                    {
                        ValorEstadia = (TempoPermanencia.Days + 1) * 60;
                    }
                    else if (TempoPermanencia.TotalMinutes <= 15)
                    {
                        ValorEstadia = 2m;
                    }
                    else if (TempoPermanencia.TotalMinutes > 15)
                    {
                        decimal valor = (decimal)TempoPermanencia.TotalHours * 5;
                        decimal.Round(valor, 2);
                        ValorEstadia = valor;
                    }
                    break;
            }
        }
        internal void SetSaida()
        {
            Saida = DateTime.Now;
        }
    }
}
