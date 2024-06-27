using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _repository;

        public RotaService(IRotaRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarRota(RotaModel rota)
        {
            _repository.Update(rota);
        }

        public void CriarRota(RotaModel rota)
        {
            _repository.Add(rota);
        }

        public void DeletarRota(int id)
        {
            var rota = _repository.GetById(id);
            if (rota != null)
            {
                _repository.Delete(rota);
            }
        }

        public IEnumerable<RotaModel> ListarRotas()
        {
            return _repository.GetAll();
        }

        public RotaModel ObterRotaPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
