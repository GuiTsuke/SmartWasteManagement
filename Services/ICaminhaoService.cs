using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface ICaminhaoService
    {
        IEnumerable<CaminhaoModel> ListarCaminhoes();
        CaminhaoModel ObterCaminhaoPorId(int id);
        void CriarCaminhao(CaminhaoModel caminhao);
        void AtualizarCaminhao(CaminhaoModel caminhao);
        void DeletarCaminhao(int id);
    }
}
