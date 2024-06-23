using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.SmartWasteManagement.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
