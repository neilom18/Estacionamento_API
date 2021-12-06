using Estacionamento_API.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estacionamento_API.Services
{
    public class ClienteService
    {
        private readonly List<Cliente> _clientes;

        public ClienteService()
        {
            _clientes = new List<Cliente>();
        }

        public IEnumerable<Cliente> Get()
        {
            return _clientes;
        }
        public Cliente Get(Guid id)
        {
            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }
        public Cliente Get(string Documento)
        {
            return _clientes.Where(x => x.Documento == Documento).FirstOrDefault();
        }
        public Cliente Adicionar(Cliente cliente)
        {
            _clientes.Add(cliente);
            return cliente;
        }
    }
}
