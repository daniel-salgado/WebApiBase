using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBase.Core.Models;
using WebApiBase.Core.Repositories;

namespace WebApiBase.Persistance.Repositories
{
    public class ProdutctRepository : IProductRepository
    {

        private ApplicationDbContext _context;

        public ProdutctRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool Exists(int id)
        {
            return _context.Products.Any(p => p.ProductID == id);
        }


        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Delete(object id)
        {

            int productId = (int)id;

            Product product = _context.Products.Find(productId);

            if (product != null)
            {
                _context.Products.Remove(product);
            }

        }

    }
}