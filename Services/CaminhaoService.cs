using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly ICaminhaoRepository _repository;

        public CaminhaoService(ICaminhaoRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarCaminhao(CaminhaoModel caminhao) => _repository.Update(caminhao);

        public void CriarCaminhao(CaminhaoModel caminhao) => _repository.Add(caminhao);

        public void DeletarCaminhao(int id)
        {
            var caminhao = _repository.GetById(id);
            if(caminhao != null)
            {
                _repository.Delete(caminhao);
            }
                
        }

        public IEnumerable<CaminhaoModel> ListarCaminhoes() => _repository.GetAll();

        public CaminhaoModel ObterCaminhaoPorId(int id) => _repository.GetById(id);
    }
}
