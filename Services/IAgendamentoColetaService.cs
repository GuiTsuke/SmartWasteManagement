using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Services
{
    public interface IAgendamentoColetaService
    {
        IEnumerable<AgendamentoColetaModel> ListarAgendamentosColeta();
        AgendamentoColetaModel ObterAgendamentoPorId(int id);
        void CriarAgendamento(AgendamentoColetaModel Agendamento);
        void AtualizarAgendamento(AgendamentoColetaModel Agendamento);
        void DeletarAgendamento(int id);
    }
}
