using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services.Interfaces;
using ReservaIngressosCinema.Util;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Services
{
    public class HorarioService : IHorarioService
    {
        IHorarioRepository horarioRepository;

        public HorarioService(IHorarioRepository repository)
        {
            horarioRepository = repository;
        }

        public void Incluir(HorarioModel horarioModel)
        {
            ValidaDadosHorario(horarioModel);

            horarioRepository.Incluir(horarioModel);
        }

        public List<HorarioModel> Listar(HorarioModel horarioModel)
        {
            return horarioRepository.Listar(horarioModel);
        }

        #region Métodos Auxiliares

        private void ValidaDadosHorario(HorarioModel horarioModel)
        {
            ValidaSeSalaNaoEstaMarcadaParaOMesmoHorario(horarioModel);
        }

        private void ValidaSeSalaNaoEstaMarcadaParaOMesmoHorario(HorarioModel horarioModel)
        {
            if (Listar(horarioModel).Count == 0)
            {
                return;
            }

            throw new ReservaIngressosCinemaException("Id", HorarioResource.SalaJaCasdastradaNoMesmoHorarioMensagem);
        }

        #endregion
    }
}
