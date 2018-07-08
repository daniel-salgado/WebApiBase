using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiBase.Core.Models;

namespace WebApiBase.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}