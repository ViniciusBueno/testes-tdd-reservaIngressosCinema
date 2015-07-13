
namespace ReservaIngressosCinema.Models
{
    public class UsuarioModel
    {
        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string RG { get; set; }

        public int? IdPerfil { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}
