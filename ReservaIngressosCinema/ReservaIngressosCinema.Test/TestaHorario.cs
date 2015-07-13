using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services;
using ReservaIngressosCinema.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservaIngressosCinema.Test
{
    [TestClass]
    public class TestaHorario
    {
        List<HorarioModel> horarios;

        public TestaHorario()
        {
            horarios = new List<HorarioModel>
            {
                new HorarioModel 
                {
                    Id = 1,
                    HoraInicio = new DateTime(2015, 1, 1, 8, 0, 0),
                    HoraTermino = new DateTime(2015, 1, 1, 9, 30, 0),
                    IdSala = 1,
                    IdFilme = 1
                },
                new HorarioModel 
                {
                    Id = 2,
                    HoraInicio = new DateTime(2015, 1, 1, 10, 0, 0),
                    HoraTermino = new DateTime(2015, 1, 1, 11, 30, 0),
                    IdSala = 2,
                    IdFilme = 1
                },
                new HorarioModel 
                {
                    Id = 3,
                    HoraInicio = new DateTime(2015, 1, 1, 10, 0, 0),
                    HoraTermino = new DateTime(2015, 1, 1, 11, 30, 0),
                    IdSala = 2,
                    IdFilme = 6
                },
            };
        }

        /// <summary>
        /// Inclusão de sala que já está cadastrada no mesmo horário.
        /// 
        /// Para que usuários sejam incluídos sem perfil.
        /// Como um atendente.
        /// Eu quero que o usuário seja incluído com o perfil Cliente.
        /// </summary>
        [TestMethod]
        public void Testa_Se_Ao_Incluir_Uma_Sala_Que_Ja_Esta_Cadastrada_No_Mesmo_Horario_Exibe_Mensagem_De_Validacao()
        {
            // Dado que o horário da sala 1 seja incluído.
            var horarioModel = new HorarioModel
            {
                HoraInicio = new DateTime(2015, 1, 1, 10, 0, 0),
                HoraTermino = new DateTime(2015, 1, 1, 11, 30, 0),
                IdSala = 1
            };

            var horariosSala1 = (from h in horarios where h.IdSala == 1 select h).ToList();

            var mock = new Mock<IHorarioRepository>();
            mock.Setup(u => u.Incluir(horarioModel)).Verifiable();
            mock.Setup(u => u.Listar(horarioModel)).Returns(horariosSala1);

            try
            {
                // Quando incluir o horário.
                var horarioService = new HorarioService(mock.Object);
                horarioService.Incluir(horarioModel);

                Assert.Fail("Expected exception was not thrown.");
            }
            catch (ReservaIngressosCinemaException ex)
            {
                // Então deve exibir mensagem que a sala já está cadastrada no horário que se deseja cadastrar.
                var mensagemEsperada = HorarioResource.SalaJaCasdastradaNoMesmoHorarioMensagem;

                Assert.AreEqual(mensagemEsperada, ex.Mensagem);
            }
        }
    }
}
