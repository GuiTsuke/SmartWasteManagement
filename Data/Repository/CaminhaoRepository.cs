using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly DatabaseContext _context;

        public CaminhaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Add(caminhao);
            _context.SaveChanges();
        }

        public void Delete(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Remove(caminhao);
            _context.SaveChanges();
        }

        public IEnumerable<CaminhaoModel> GetAll() => _context.Caminhoes.ToList();

        public CaminhaoModel GetById(int id) => _context.Caminhoes.Find(id);

        public void Update(CaminhaoModel caminhao)
        {
            _context.Caminhoes.Update(caminhao);
            _context.SaveChanges();
        }
    }
}
