using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public interface IAgendamentoColetaRepository
    {
        IEnumerable<AgendamentoColetaModel> GetAll();
        AgendamentoColetaModel GetById(int id);
        void Add(AgendamentoColetaModel agendamento);
        void Update(AgendamentoColetaModel agendamento);
        void Delete(AgendamentoColetaModel agendamento);
    }
}
