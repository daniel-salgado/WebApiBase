using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebApiBase.Core.Models;

namespace WebApiBase.Persistance
{

    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public DbSet<Product> Products { get; set; }

    }

}
