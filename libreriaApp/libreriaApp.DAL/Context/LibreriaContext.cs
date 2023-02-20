using libreriaApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace libreriaApp.DAL.Context
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext()
        { }
        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        
        }
        #region "Publishers"
        public DbSet<Publisher> publishers { get; set; }
        #endregion
    }
}