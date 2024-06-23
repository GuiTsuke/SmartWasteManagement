namespace Fiap.Web.SmartWasteManagement.Models
{
    public class RotaModel
    {
        public int Codigo { get; set; }
        public int CodigoCaminhao { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public string PontosColeta { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public List<AgendamentoColetaModel> Agendamentos { get; set; }
    }
}
