using System.Collections.Generic;
using DemoApp.Data.Entities;

namespace DemoApp.Data
{
    public interface IDemoAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        bool SaveAll();
        
    }
}