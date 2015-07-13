using ReservaIngressosCinema.Models;

namespace ReservaIngressosCinema.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        void Incluir(UsuarioModel usuarioModel);
    }
}
