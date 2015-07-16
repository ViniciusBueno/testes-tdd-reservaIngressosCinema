using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        public void Incluir(HorarioModel horarioModel)
        {
            // Executa a inclusão no banco.
        }

        public List<HorarioModel> Listar(HorarioModel horarioModel)
        {
            // Busca no banco.

            return new List<HorarioModel>();
        }
    }
}
