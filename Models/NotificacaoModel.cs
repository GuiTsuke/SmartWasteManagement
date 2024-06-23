using Fiap.Web.SmartWasteManagement.Models.Enums;

namespace Fiap.Web.SmartWasteManagement.Models
{
    public class NotificacaoModel
    {
        public int Codigo { get; set; }
        public DateTime DataEnvio { get; set; }
        public NotificacaoStatus Tipo { get; set; }
        public LeituraStatus Leitura { get; set; }
        public int CodigoMorador { get; set; }
        public MoradorModel Morador { get; set; }
        public int CodigoRecipiente { get; set; }
        public RecipienteModel Recipiente { get; set; }

    }
}
