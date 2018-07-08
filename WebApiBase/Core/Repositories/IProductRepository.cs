using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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