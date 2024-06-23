using Fiap.Web.SmartWasteManagement.Models.Enums;

namespace Fiap.Web.SmartWasteManagement.Models
{
    public class CaminhaoModel
    {
        public int Codigo { get; set; }
        public string Placa { get; set; }
        public decimal CapacidadeCarga { get; set; }
        public CaminhaoStatus Status { get; set; }
        public string LocalizacaoAtual { get; set; }
        public List<RotaModel> Rotas { get; set; }
    }
}
