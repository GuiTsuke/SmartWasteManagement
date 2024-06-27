using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public class RecipienteService : IRecipienteService
    {
        private readonly IRecipienteRepository _repository;

        public RecipienteService(IRecipienteRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarRecipiente(RecipienteModel recipiente)
        {
            _repository.Update(recipiente);
        }

        public void CriarRecipiente(RecipienteModel recipiente)
        {
            _repository.Add(recipiente);
        }

        public void DeletarRecipiente(int id)
        {
            var recipiente = _repository.GetById(id);
            if (recipiente != null)
            {
                _repository.Delete(recipiente);
            }
        }

        public IEnumerable<RecipienteModel> ListarRecipientes()
        {
            return _repository.GetAll();
        }

        public RecipienteModel ObterRecipientePorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
