using ReservaIngressosCinema.Models;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        void Incluir(ReservaModel reservaModel);
        List<ReservaModel> ListarComObjetosFilhos(ReservaModel reservaModel);
    }
}
