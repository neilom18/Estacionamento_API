using System;
using System.Collections.Generic;

namespace Estacionamento_API.Entidades
{
    public class Cliente
    {
        public Cliente(string nome, string documento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Veiculos = new List<Veiculo>();
        }

        public Guid Id { get;private set; }  
        public string Nome { get;private set; }
        public string Documento { get;private set; }
        public List<Veiculo> Veiculos { get;private set; }
    }
}
