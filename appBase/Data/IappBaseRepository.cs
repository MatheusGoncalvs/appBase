using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace appBase.Data
{
    public interface IappBaseRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}