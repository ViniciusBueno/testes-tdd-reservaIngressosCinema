using ReservaIngressosCinema.Models;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Services.Interfaces
{
    public interface IHorarioService
    {
        void Incluir(HorarioModel horarioModel);

        List<HorarioModel> Listar(HorarioModel horarioModel);
    }
}
