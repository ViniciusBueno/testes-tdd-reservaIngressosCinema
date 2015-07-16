
namespace ReservaIngressosCinema.Models
{
    public class ReservaModel : BaseModel
    {
        public int QuantidadeIngressos { get; set; }

        public int IdHorario { get; set; }

        public int IdUsuario { get; set; }

        public HorarioModel HorarioModel { get; set; }

        public ReservaModel()
        {
            HorarioModel = new HorarioModel();
        }
    }
}
