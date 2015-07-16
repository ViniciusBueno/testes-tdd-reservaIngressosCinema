using ReservaIngressosCinema.Models;
using ReservaIngressosCinema.Repositories.Interfaces;
using System.Collections.Generic;

namespace ReservaIngressosCinema.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        public void Incluir(ReservaModel reservaModel)
        {
            // Executa a inclusão no banco.
        }

        public List<ReservaModel> ListarComObjetosFilhos(ReservaModel reservaModel)
        {
            // Busca no banco.

            return new List<ReservaModel>();
        }
    }
}
