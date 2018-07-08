using WebApiBase.Core.Repositories;

namespace WebApiBase.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        void Save();

    }
}