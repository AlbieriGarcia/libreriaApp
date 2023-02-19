using Microsoft.EntityFrameworkCore;
using libreriaApp.DAL.Entities;

namespace libreriaApp.DAL.Context
{
    public class LibreriaContext : DbContext
    {
      public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {
            
        }
        #region "Registros"
        public DbSet<Authors> Authors { get; set; }
        #endregion
    }
}
