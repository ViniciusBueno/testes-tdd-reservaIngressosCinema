using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Resources;
using ReservaIngressosCinema.Services.Interfaces;
using ReservaIngressosCinema.Util;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Services
{
    public class ReservaService : IReservaService
    {
        IReservaRepository reservaRepository;

        SalaService salaService;

        public ReservaService(IReservaRepository repository, ISalaRepository salaRepository)
        {
            reservaRepository = repository;

            salaService = new SalaService(salaRepository);
        }

        public void Incluir(ReservaModel reservaModel)
        {
            ValidaIncluir(reservaModel);

            reservaRepository.Incluir(reservaModel);
        }

        public List<ReservaModel> ListarComObjetosFilhos(ReservaModel reservaModel)
        {
            return reservaRepository.ListarComObjetosFilhos(reservaModel);
        }

        #region Métodos Auxiliares

        private void ValidaIncluir(ReservaModel reservaModel)
        {
            ValidaSalaLotada(reservaModel);
        }

        private void ValidaSalaLotada(ReservaModel reservaModel)
        {
            if (BuscaQuantidadeReservasParaOHorario(reservaModel) < BuscaQuantidadeSalaReservada(reservaModel))
            {
                return;
            }

            throw new ReservaIngressosCinemaException("Id", ReservaResource.SalaLotadaMensagem);
        }

        private int BuscaQuantidadeReservasParaOHorario(ReservaModel reservaModel)
        {
            var reservaModelFiltro = new ReservaModel
            {
                IdHorario = reservaModel.IdHorario
            };

            var reservas = ListarComObjetosFilhos(reservaModelFiltro);

            return reservas.Count;
        }

        private int BuscaQuantidadeSalaReservada(ReservaModel reservaModel)
        {
            var salaModel = new SalaModel
            {
                Id = reservaModel.HorarioModel.IdSala
            };

            salaModel = salaService.Buscar(salaModel);

            return salaModel.QuantidadeLugares;
        }

        #endregion
    }
}
