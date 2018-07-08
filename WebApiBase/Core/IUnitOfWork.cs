using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiBase.Core.Repositories;

namespace WebApiBase.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        void Save();

    }
}