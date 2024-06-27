using Fiap.Web.SmartWasteManagement.Models.Enums;

namespace Fiap.Web.SmartWasteManagement.Models
{
    public class RecipienteModel
    {
        public int Codigo { get; set; }
        public string Endereco { get; set; }
        public TipoResiduo TipoResiduo { get; set; }
        public decimal CapacidadeTotal { get; set; }
        public decimal NivelOcupacaoAtual { get; set; }
        public int CodigoMorador { get; set; }
        public MoradorModel Morador { get; set; }

        public List<NotificacaoModel> Notificacoes { get; set; }
        public List<AgendamentoColetaModel> Agendamentos { get; set; }
    }
}
