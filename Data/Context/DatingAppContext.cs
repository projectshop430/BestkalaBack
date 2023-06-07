using Domain.Entitis.Product;
using Domain.Entitis.user;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DatingAppContext:DbContext
    {
        #region constractore
        public DatingAppContext(DbContextOptions<DatingAppContext> options) : base(options) { 


        }
        #endregion
        public DbSet<User> Users { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
