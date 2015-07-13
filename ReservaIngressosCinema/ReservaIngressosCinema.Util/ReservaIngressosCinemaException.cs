using System;

namespace ReservaIngressosCinema.Util
{
    public class ReservaIngressosCinemaException : Exception
    {
        public string IdCampo { get; set; }

        public string Mensagem { get; set; }

        public ReservaIngressosCinemaException(string idCampo, string mensagem)
        {
            IdCampo = idCampo;
            Mensagem = mensagem;
        }
    }
}
