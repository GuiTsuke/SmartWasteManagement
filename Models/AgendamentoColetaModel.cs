namespace Fiap.Web.SmartWasteManagement.Models
{
    public class AgendamentoColetaModel
    {
        public int Codigo { get; set; }
        public int CodigoRecipiente { get; set; }
        public int CodigoRota { get; set; }
        public DateTime DataAgendamento { get; set; }
        public RecipienteModel Recipiente { get; set; }
        public RotaModel Rota { get; set; }
    }
}
