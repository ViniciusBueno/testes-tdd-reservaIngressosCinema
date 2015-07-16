using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using ReservaIngressosCinema.Services.Interfaces;

namespace ReservaIngressosCinema.Services
{
    public class SalaService : ISalaService
    {
        ISalaRepository salaRepository;

        public SalaService(ISalaRepository repository)
        {
            salaRepository = repository;
        }

        public SalaModel Buscar(SalaModel salaModel)
        {
            return salaRepository.Buscar(salaModel);
        }
    }
}
