using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class MoradorRepository : IMoradorRepository
    {
        private readonly DatabaseContext _context;

        public MoradorRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(MoradorModel morador)
        {
            _context.Moradores.Add(morador);
            _context.SaveChanges();
        }

        public void Delete(MoradorModel morador)
        {
            _context.Moradores.Remove(morador);
            _context.SaveChanges();
        }

        public void Update(MoradorModel morador)
        {
            _context.Moradores.Update(morador);
            _context.SaveChanges();
        }

        IEnumerable<MoradorModel> IMoradorRepository.GetAll()
        {
           return _context.Moradores.ToList();
        }

        MoradorModel IMoradorRepository.GetById(int id)
        {
            return _context.Moradores.Find(id);
        }
    }
}
