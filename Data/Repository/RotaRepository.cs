using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class RotaRepository : IRotaRepository
    {
        private readonly DatabaseContext _context;
        public RotaRepository(DatabaseContext context)
        {
            _context = context;
        }
        IEnumerable<RotaModel> IRotaRepository.GetAll()
        {
            return _context.Rotas.ToList();
        }

        RotaModel IRotaRepository.GetById(int id)
        {
            return _context.Rotas.Find(id);
        }

        public void Add(RotaModel rota)
        {
            _context.Rotas.Add(rota);
            _context.SaveChanges();
        }

        public void Update(RotaModel rota)
        {
            _context.Rotas.Update(rota);
            _context.SaveChanges();
        }

        public void Delete(RotaModel rota)
        {
            _context.Rotas.Remove(rota);
            _context.SaveChanges();
        }
    }
}
