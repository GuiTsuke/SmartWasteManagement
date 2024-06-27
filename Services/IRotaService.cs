using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface IRotaService
    {
        IEnumerable<RotaModel> ListarRotas();
        RotaModel ObterRotaPorId(int id);
        void CriarRota(RotaModel rota);
        void AtualizarRota(RotaModel rota);
        void DeletarRota(int id);
    }
}
