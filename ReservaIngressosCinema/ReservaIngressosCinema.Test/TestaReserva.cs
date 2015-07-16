using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services;
using ReservaIngressosCinema.Util;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Test
{
    [TestClass]
    public class TestaReserva
    {
        public TestaReserva()
        {

        }

        /// <summary>
        /// Reserva de uma sala que já está lotada.
        /// 
        /// Para que uma reserva seja feita.
        /// Como um cliente.
        /// Eu quero que o usuário seja incluído com o perfil Cliente.
        /// </summary>
        [TestMethod]
        public void Testa_Se_For_Feita_Uma_Reserva_De_Sala_Que_Ja_Esta_Lotada_Exibe_Mensagem_De_Validacao()
        {
            // Dado que a reserva seja feita.
            var reservaModel = new ReservaModel
            {
                QuantidadeIngressos = 1,
                IdHorario = 1,
                IdUsuario = 7,
                HorarioModel = new HorarioModel { IdSala = 1 }
            };

            var salaModel = new SalaModel
            {
                Id = 1,
                QuantidadeLugares = 5,
                Nome = "Sala 01",
                Descricao = "Sala para exibições 3D."

            };

            var horarioModel = new HorarioModel { Id = 1, IdSala = 1, IdFilme = 3 };

            var reservas = new List<ReservaModel>
            {
                new ReservaModel { Id = 1, IdHorario = 1, IdUsuario = 1, HorarioModel = horarioModel },
                new ReservaModel { Id = 2, IdHorario = 1, IdUsuario = 2, HorarioModel = horarioModel },
                new ReservaModel { Id = 3, IdHorario = 1, IdUsuario = 3, HorarioModel = horarioModel },
                new ReservaModel { Id = 4, IdHorario = 1, IdUsuario = 4, HorarioModel = horarioModel },
                new ReservaModel { Id = 5, IdHorario = 1, IdUsuario = 5, HorarioModel = horarioModel }
            };

            var mock = new Mock<IReservaRepository>();
            mock.Setup(u => u.Incluir(reservaModel)).Verifiable();
            mock.Setup(u => u.ListarComObjetosFilhos(It.IsAny<ReservaModel>())).Returns(reservas);

            var salaMock = new Mock<ISalaRepository>();
            salaMock.Setup(u => u.Buscar(It.IsAny<SalaModel>())).Returns(salaModel);

            try
            {
                // Quando a reserva for feita.
                var reservaService = new ReservaService(mock.Object, salaMock.Object);
                reservaService.Incluir(reservaModel);

                Assert.Fail("A reserva não poderia ser feita, pois a sala já está lotada.");
            }
            catch (ReservaIngressosCinemaException ex)
            {
                // Então deve exibir mensagem que a sala está lotada.
                var mensagemEsperada = ReservaResource.SalaLotadaMensagem;

                Assert.AreEqual(mensagemEsperada, ex.Mensagem);
            }
        }
    }
}
