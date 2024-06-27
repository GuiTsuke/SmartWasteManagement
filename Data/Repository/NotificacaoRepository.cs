using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly DatabaseContext _context;

        public NotificacaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(NotificacaoModel notificacao)
        {
            _context.Notificacoes.Add(notificacao);
            _context.SaveChanges();
        }

        public void Delete(NotificacaoModel notificacao)
        {
            _context.Notificacoes.Remove(notificacao);
            _context.SaveChanges();
        }

        public IEnumerable<NotificacaoModel> GetAll()
        {
            return _context.Notificacoes.ToList();
        }

        public NotificacaoModel GetById(int id)
        {
            return _context.Notificacoes.Find(id);
        }

        public void Update(NotificacaoModel notificacao)
        {
            _context.Notificacoes.Update(notificacao);
            _context.SaveChanges();
        }
    }
}
