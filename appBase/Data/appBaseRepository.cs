using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public appBaseRepository(appBaseContext context, ILogger<appBaseRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts was called.");

                return context.Products
                .OrderBy(p => p.Title)
                .ToList();
            }
            catch(Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
            
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
