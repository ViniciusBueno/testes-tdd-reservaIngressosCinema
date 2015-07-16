using System;

namespace ReservaIngressosCinema.Models
{
    public class HorarioModel : BaseModel
    {
        public DateTime HoraInicio { get; set; }

        public DateTime HoraTermino { get; set; }

        public int IdSala { get; set; }

        public int IdFilme { get; set; }
    }
}
