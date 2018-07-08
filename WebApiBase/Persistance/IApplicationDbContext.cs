using System.Data.Entity;
using WebApiBase.Core.Models;

namespace WebApiBase.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}