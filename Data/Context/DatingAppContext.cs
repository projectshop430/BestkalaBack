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
    public class BestKalaContext:DbContext
    {
        #region constractore
        public BestKalaContext(DbContextOptions<BestKalaContext> options) : base(options) { 


        }
        #endregion
        public DbSet<User> Users { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
