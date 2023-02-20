using libreriaApp.DAL.Core;
using libreriaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace libreriaApp.DAL.Context
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) 
            : base(options) 
        {
        }
        
        #region "Registros"
        public DbSet<Sales>? sales { get; set; }
        public object? Sales { get; internal set; }
        #endregion

    }
}
