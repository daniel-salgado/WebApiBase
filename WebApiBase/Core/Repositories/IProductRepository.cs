using System.Collections.Generic;
using WebApiBase.Core.Models;

namespace WebApiBase.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        bool Exists(int id);
    }
}