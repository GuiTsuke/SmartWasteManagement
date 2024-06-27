using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface IRecipienteService
    {
        IEnumerable<RecipienteModel> ListarRecipientes();
        RecipienteModel ObterRecipientePorId(int id);
        void CriarRecipiente(RecipienteModel recipiente);
        void AtualizarRecipiente(RecipienteModel recipiente);
        void DeletarRecipiente(int id);
    }
}
