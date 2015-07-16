using ReservaIngressosCinema.Models;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Services.Interfaces
{
    public interface IReservaService
    {
        void Incluir(ReservaModel reservaModel);

        List<ReservaModel> ListarComObjetosFilhos(ReservaModel reservaModel);
    }
}
