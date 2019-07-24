using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBase.Data
{
    public class appBaseRepository : IappBaseRepository
    {
        private readonly appBaseContext context;

        public appBaseRepository(appBaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products
                .OrderBy(p => p.Title)
                .ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
