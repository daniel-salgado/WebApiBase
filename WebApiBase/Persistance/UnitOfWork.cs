using WebApiBase.Core;
using WebApiBase.Core.Repositories;
using WebApiBase.Persistance.Repositories;

namespace WebApiBase.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _context;
        private ProdutctRepository _produtctRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _produtctRepository = new ProdutctRepository(context);
        }

        public IProductRepository Products
        {
            get
            {
                if (_produtctRepository == null)
                    _produtctRepository = new ProdutctRepository(_context);

                return _produtctRepository;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}