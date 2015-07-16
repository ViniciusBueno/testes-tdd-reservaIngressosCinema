using ReservaIngressosCinema.Models;

namespace ReservaIngressosCinema.Repositories.Interfaces
{
    public interface ISalaRepository
    {
        SalaModel Buscar(SalaModel SalaModel);
    }
}
