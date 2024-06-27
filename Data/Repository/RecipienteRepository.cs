using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;

namespace Fiap.Web.SmartWasteManagement.Data.Repository
{
    public class RecipienteRepository : IRecipienteRepository
    {
        private readonly DatabaseContext _context;

        public RecipienteRepository(DatabaseContext context)
        {
            _context = context;
        }

        void IRecipienteRepository.Add(RecipienteModel recipiente)
        {
            _context.Recipientes.Add(recipiente);
            _context.SaveChanges();
        }

        void IRecipienteRepository.Delete(RecipienteModel recipiente)
        {
            _context.Recipientes.Remove(recipiente);
            _context.SaveChanges();
        }

        IEnumerable<RecipienteModel> IRecipienteRepository.GetAll()
        {
            return _context.Recipientes.ToList();
        }

        RecipienteModel IRecipienteRepository.GetById(int id)
        {
            return _context.Recipientes.Find(id);
        }

        void IRecipienteRepository.Update(RecipienteModel recipiente)
        {
            _context.Recipientes.Update(recipiente);
            _context.SaveChanges();
        }
    }
}
