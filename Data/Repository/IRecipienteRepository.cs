using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public interface IRecipienteRepository
    {
        IEnumerable<RecipienteModel> GetAll();
        RecipienteModel GetById(int id);
        void Add(RecipienteModel recipiente);
        void Update(RecipienteModel recipiente);
        void Delete(RecipienteModel recipiente);
    }
}
