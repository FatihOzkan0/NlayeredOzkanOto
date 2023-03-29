using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
