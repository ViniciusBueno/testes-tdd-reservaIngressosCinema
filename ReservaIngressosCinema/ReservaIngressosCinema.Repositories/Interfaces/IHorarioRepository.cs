using ReservaIngressosCinema.Models;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Repositories.Interfaces
{
    public interface IHorarioRepository
    {
        void Incluir(HorarioModel horarioModel);

        List<HorarioModel> Listar(HorarioModel horarioModel);
    }
}
