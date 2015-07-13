using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services.Interfaces;
using ReservaIngressosCinema.Util;

namespace ReservaIngressosCinema.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            usuarioRepository = repository;
        }

        public void Incluir(UsuarioModel usuarioModel)
        {
            ValidaDadosUsuario(usuarioModel);

            AtribuiPerfilClienteCasoUsuarioNaoTenhaPerfil(usuarioModel);

            usuarioRepository.Incluir(usuarioModel);
        }

        #region Métodos Auxiliares

        private void ValidaDadosUsuario(UsuarioModel usuarioModel)
        {
            ValidaCampoNomeUsuario(usuarioModel);
        }

        private void ValidaCampoNomeUsuario(UsuarioModel usuarioModel)
        {
            if (string.IsNullOrEmpty(usuarioModel.Nome))
            {
                throw new ReservaIngressosCinemaException("Id", UsuarioResource.NomeObrigatorioMensagem);
            }
        }

        private void AtribuiPerfilClienteCasoUsuarioNaoTenhaPerfil(UsuarioModel usuarioModel)
        {
            if (!usuarioModel.IdPerfil.HasValue)
            {
                usuarioModel.IdPerfil = (int)ReservaIngressosCinema.Util.Enums.Perfil.Cliente;
            }
        }

        #endregion
    }
}
