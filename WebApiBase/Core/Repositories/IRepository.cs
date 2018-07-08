using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBase.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object id);


    }
}