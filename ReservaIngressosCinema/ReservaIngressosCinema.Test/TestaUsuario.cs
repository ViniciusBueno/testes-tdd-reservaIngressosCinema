using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services;
using ReservaIngressosCinema.Util;

namespace ReservaIngressosCinema.Test
{
    [TestClass]
    public class TestaUsuario
    {
        UsuarioModel usuarioModel;

        public TestaUsuario()
        {
            usuarioModel = new UsuarioModel
            {
                Nome = "Vinícius Silveira",
                Endereco = "Dr. Luis, 4444",
                Telefone = "39678452",
                RG = "96784512",
                Id = (int)ReservaIngressosCinema.Util.Enums.Perfil.Cliente,
                Login = "vbsilveira",
                Senha = "123456"
            };
        }

        /// <summary>
        /// Inclusão de usuário sem perfil.
        /// 
        /// Para que usuários sejam incluídos sem perfil.
        /// Como um usuário.
        /// Eu quero que o usuário seja incluído com o perfil Cliente.
        /// </summary>
        [TestMethod]
        public void Testa_Se_Ao_Incluir_Usuario_Sem_Perfil_Inclui_Usuario_Com_O_Perfil_Cliente()
        {
            // Dado que o usuário seja incluído sem perfil.
            usuarioModel.IdPerfil = null;

            var mock = new Mock<IUsuarioRepository>();
            mock.Setup(u => u.Incluir(usuarioModel)).Verifiable();

            // Quando incluir o usuário.
            var usuarioService = new UsuarioService(mock.Object);
            usuarioService.Incluir(usuarioModel);

            // Então deve ser incluído o usuário com perfil Cliente.
            var perfilEsperado = (int)ReservaIngressosCinema.Util.Enums.Perfil.Cliente;

            Assert.AreEqual(perfilEsperado, usuarioModel.IdPerfil);
        }

        /// <summary>
        /// Inclusão de usuário sem Nome.
        /// 
        /// Para que usuários sejam incluídos com sucesso.
        /// Como um usuário.
        /// Eu quero que o usuário possua um Nome.
        /// </summary>
        [TestMethod]
        public void Testa_Se_Ao_Incluir_Usuario_Sem_Nome_Exibe_Mensagem_De_Validacao()
        {
            // Dado que o usuário seja incluído sem o seu Nome.
            usuarioModel.Nome = string.Empty;

            var mock = new Mock<IUsuarioRepository>();
            mock.Setup(u => u.Incluir(usuarioModel)).Verifiable();

            try
            {
                // Quando incluir o usuário.
                var usuarioService = new UsuarioService(mock.Object);
                usuarioService.Incluir(usuarioModel);

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ReservaIngressosCinemaException ex)
            {
                // Então deve exibir mensagem que o campo Nome é obrigatório.
                var mensagemEsperada = UsuarioResource.NomeObrigatorioMensagem;

                Assert.AreEqual(mensagemEsperada, ex.Mensagem);
            }
        }
    }
}
