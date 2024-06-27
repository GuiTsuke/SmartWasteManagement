using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class AgendamentoColetaRepository : IAgendamentoColetaRepository
    {
        private readonly DatabaseContext _context;

        public AgendamentoColetaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(AgendamentoColetaModel agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public void Delete(AgendamentoColetaModel agendamento)
        {
            _context.Agendamentos.Remove(agendamento);
            _context.SaveChanges();
        }

        public IEnumerable<AgendamentoColetaModel> GetAll()
        {
            return _context.Agendamentos.ToList();
        }

        public AgendamentoColetaModel GetById(int id)
        {
            return _context.Agendamentos.Find(id);
        }

        public void Update(AgendamentoColetaModel agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            _context.SaveChanges();
        }
    }
}
