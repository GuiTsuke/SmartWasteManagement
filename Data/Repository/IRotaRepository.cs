using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public interface IRotaRepository
    {
        IEnumerable<RotaModel> GetAll();
        RotaModel GetById(int id);
        void Add(RotaModel rota);
        void Update(RotaModel rota);
        void Delete(RotaModel rota);
    }
}
