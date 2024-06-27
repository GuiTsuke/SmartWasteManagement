using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public interface IMoradorRepository
    {
        IEnumerable<MoradorModel> GetAll();
        MoradorModel GetById(int id);
        void Add(MoradorModel morador);
        void Update(MoradorModel morador);
        void Delete(MoradorModel morador);
    }
}
