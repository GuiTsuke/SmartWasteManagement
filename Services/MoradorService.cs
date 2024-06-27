using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _repository;

        public MoradorService(IMoradorRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarMorador(MoradorModel morador)
        {
            _repository.Update(morador);
        }

        public void CriarMorador(MoradorModel morador)
        {
            _repository.Add(morador);
        }

        public void DeletarMorador(int id)
        {
            var morador = _repository.GetById(id);
            if (morador != null)
            {
                _repository.Delete(morador);
            }
        }

        public IEnumerable<MoradorModel> ListarMoradores()
        {
            return _repository.GetAll();
        }

        public MoradorModel ObterMoradorPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
