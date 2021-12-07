namespace Estacionamento_API.DTOs
{
    public class ClienteDTO : Validator
    {
        public string Nome { get; set; }
        public string Documento { get; set; }

        public override void Validar()
        {
            Valido = true;
            if (Nome.Length < 4) Valido = false;
        }
    }
}
