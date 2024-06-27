using Fiap.Web.SmartWasteManagement.Data.Repository;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public class AgendamentoColetaService : IAgendamentoColetaService
    {
        private readonly IAgendamentoColetaRepository _repository;

        public AgendamentoColetaService(IAgendamentoColetaRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarAgendamento(AgendamentoColetaModel agendamento)
        {
            _repository.Update(agendamento);
        }

        public void CriarAgendamento(AgendamentoColetaModel agendamento)
        {
            _repository.Add(agendamento);
        }

        public void DeletarAgendamento(int id)
        {
            var agendamento = _repository.GetById(id);
            if (agendamento != null)
            {
                _repository.Delete(agendamento);
            }
        }

        public IEnumerable<AgendamentoColetaModel> ListarAgendamentosColeta()
        {
            return _repository.GetAll();
        }

        public AgendamentoColetaModel ObterAgendamentoPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}
