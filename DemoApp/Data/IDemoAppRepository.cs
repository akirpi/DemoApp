using System.Collections.Generic;
using DemoApp.Data.Entities;

namespace DemoApp.Data
{
    public interface IDemoAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
    }
}