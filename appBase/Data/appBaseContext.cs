using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBase.Data
{
    public class appBaseContext : DbContext
    {
        //Pega a connectionString e passa para o dbContext. Assim ele sabe qual connectionString utilizar.
        public appBaseContext(DbContextOptions<appBaseContext> options):base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
