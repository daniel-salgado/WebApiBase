using System.Data.Entity;
using WebApiBase.Core.Models;

namespace WebApiBase.Persistance
{

    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<Product> Products { get; set; }

    }

}
