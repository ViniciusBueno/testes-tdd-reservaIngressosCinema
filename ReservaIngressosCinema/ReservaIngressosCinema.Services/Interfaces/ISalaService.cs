using ReservaIngressosCinema.Models;

namespace ReservaIngressosCinema.Services.Interfaces
{
    public interface ISalaService
    {
        SalaModel Buscar(SalaModel salaModel);
    }
}
